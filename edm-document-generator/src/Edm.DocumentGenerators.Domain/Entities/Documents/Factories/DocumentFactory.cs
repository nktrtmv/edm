using Edm.DocumentGenerators.Domain.Entities.Documents.Factories.Audits;
using Edm.DocumentGenerators.Domain.Entities.Documents.Factories.CreationContext;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentGenerator.Events.DocumentChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Services.Validators;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Errors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Errors.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Factories;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Factories;

public static class DocumentFactory
{
    public static Document CreateNew(DocumentCreationContext context)
    {
        if (context.Template.IsDeleted)
        {
            throw new BusinessLogicApplicationException("Can't create document from deleted template");
        }

        DocumentPrototype? prototype = context.Template.DocumentPrototype;

        var id = Id<Document>.CreateNew();

        DocumentStatusStateMachine? statusStateMachine = DocumentStatusStateMachineFactory.CreateFrom(prototype.StatusTransitions);

        DocumentStatus? status = statusStateMachine.GetRequiredInitialStatus();

        DocumentAttributeValue[]? attributesValues = prototype.Attributes.Select(a => DocumentAttributeValueFactory.CreateFrom(a, context)).ToArray();

        AttributesValuesAreDistinctValidator.Validate(attributesValues);

        DocumentErrors? documentErrors = DocumentErrorsFactory.CreateNew();

        DocumentNotification[] notifications = context.Template.DocumentPrototype.Notifications;

        UtcDateTime<DocumentTemplate> approvalAttributesVersion = UtcDateTimeConverterFrom<DocumentTemplate>.From(context.Template.ApprovalData.AttributesVersion!.Value);

        DocumentApprovalData? approvalData = DocumentApprovalDataFactory.CreateFrom(approvalAttributesVersion);

        DocumentSigningData? signingData = DocumentSigningDataFactory.CreateNew();

        Metadata<Front> frontMetadata = MetadataConverterFrom<Front>.From(prototype.FrontMetadata);

        Audit<Document> audit = DocumentAuditFactory.CreateNew(context.CurrentUserId, attributesValues);

        DocumentParameters? parameters = context.Template.DocumentPrototype.Parameters;

        var applicationEvents = new List<DocumentApplicationEvent> { new DocumentChangedDocumentGeneratorEventDocumentApplicationEvent() };

        var concurrencyToken = ConcurrencyToken<Document>.Empty;

        UtcDateTime<DocumentTemplate> templateUpdatedDate = UtcDateTimeConverterFrom<DocumentTemplate>.From(context.Template.Audit.Brief.UpdatedDateTime);

        var result = new Document(
            context.Template.DomainId,
            id,
            context.Template.Id,
            context.Template.SystemName,
            status,
            statusStateMachine,
            attributesValues,
            documentErrors,
            prototype.Validators,
            notifications,
            approvalData,
            signingData,
            frontMetadata,
            audit,
            parameters,
            applicationEvents,
            concurrencyToken,
            templateUpdatedDate);

        return result;
    }

    public static Document CreateFromDb(
        DomainId domainId,
        Id<Document> id,
        Id<DocumentTemplate> templateId,
        SystemName? templateSystemName,
        Id<DocumentStatus> statusId,
        DocumentStatusTransition[] statusTransitions,
        DocumentAttributeValue[] attributesValues,
        DocumentErrors documentErrors,
        DocumentValidator[] validators,
        DocumentNotification[] notifications,
        DocumentApprovalData approvalData,
        DocumentSigningData signingData,
        Metadata<Front> frontMetadata,
        Audit<Document> audit,
        List<DocumentApplicationEvent> applicationEvents,
        ConcurrencyToken<Document> concurrencyToken,
        UtcDateTime<DocumentTemplate>? templateUpdatedDate,
        DocumentParameters parameters)
    {
        DocumentStatusStateMachine? statusStateMachine = DocumentStatusStateMachineFactory.CreateFromDb(statusTransitions);

        DocumentStatus? status = statusStateMachine.GetRequiredStatusById(statusId);

        var result = new Document(
            domainId,
            id,
            templateId,
            templateSystemName,
            status,
            statusStateMachine,
            attributesValues,
            documentErrors,
            validators,
            notifications,
            approvalData,
            signingData,
            frontMetadata,
            audit,
            parameters,
            applicationEvents,
            concurrencyToken,
            templateUpdatedDate);

        return result;
    }
}
