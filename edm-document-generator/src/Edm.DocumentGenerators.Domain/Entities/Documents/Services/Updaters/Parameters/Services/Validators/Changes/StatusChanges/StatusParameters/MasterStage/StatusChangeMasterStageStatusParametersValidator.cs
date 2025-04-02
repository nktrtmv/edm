using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByIds.References;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.ReferenceAttributes;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges.StatusParameters.MasterStage;

internal static class StatusChangeMasterStageStatusParametersValidator
{
    internal static void Validate(DocumentStatusTransition transition, Document document)
    {
        DocumentStatus? statusTo = transition.To;

        bool isApprovalStage = statusTo.Type is DocumentStatusType.Approval;

        Id<DocumentAttribute>? stageOwnerAttributeValueId =
            ReferenceAttributeStatusParameterDetector.GetValueOrNull(statusTo, DocumentStatusParameterKind.StageOwner);

        if (isApprovalStage)
        {
            ValidateMasterApprovalStatusParameters(stageOwnerAttributeValueId, statusTo);
        }
        else
        {
            ValidateMasterOwnerStatusParameters(stageOwnerAttributeValueId, document, statusTo);
        }
    }

    private static void ValidateMasterApprovalStatusParameters(Id<DocumentAttribute>? stageOwnerAttributeValueId, DocumentStatus status)
    {
        if (stageOwnerAttributeValueId is null)
        {
            return;
        }

        throw new BusinessLogicApplicationException(
            $"""
             The stage owner parameter can't be specified on this stage.
             Status: {status}
             """);
    }

    private static void ValidateMasterOwnerStatusParameters(Id<DocumentAttribute>? stageOwnerAttributeValueId, Document document, DocumentStatus statusTo)
    {
        Id<User>? ownerId = FetchStageOwnerId(document, stageOwnerAttributeValueId);

        if (ownerId is not null)
        {
            return;
        }

        throw new BusinessLogicApplicationException(
            $"""
             The stage owner parameter must be specified on this stage.
             Status: {statusTo}
             """);
    }

    private static Id<User>? FetchStageOwnerId(Document document, Id<DocumentAttribute>? stageOwnerAttributeValueId)
    {
        if (stageOwnerAttributeValueId is null)
        {
            return null;
        }

        var fetcher = new DocumentAttributesValuesFetcher(document.AttributesValues);

        var selector = new DocumentReferenceAttributeValueByIdSelector(stageOwnerAttributeValueId, DocumentAttributeReferenceTypes.Employees);

        string? stageOwnerId = fetcher.FetchSingleAttributeWithSingleValueOrNull(selector);

        if (stageOwnerId is null)
        {
            return null;
        }

        Id<User> result = IdConverterFrom<User>.FromString(stageOwnerId);

        return result;
    }
}
