using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses.StatusChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.StatusChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings.Factories;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.StatusChanged.Factories;

public static class DocumentStatusChangedAuditRecordFactory
{
    internal static DocumentStatusChangedAuditRecord CreateFrom(DocumentStatusChangedEventArgs args)
    {
        AuditRecordHeading<Document> heading = AuditRecordHeadingFactory<Document>.CreateNew(args.Context.ActorId);

        AuditRecordChange<Id<DocumentStatus>> change = CreateChange(args.Change);

        DocumentStatusTransitionParameterValue[] statusTransitionParametersValues = args.Change.StatusTransitionParametersValues;

        DocumentStatusChangedAuditRecord result = CreateFromDb(heading, change, statusTransitionParametersValues);

        return result;
    }

    private static AuditRecordChange<Id<DocumentStatus>> CreateChange(DocumentStatusChange change)
    {
        var result = new AuditRecordChange<Id<DocumentStatus>>(change.Transition.From.Id, change.Transition.To.Id);

        return result;
    }

    public static DocumentStatusChangedAuditRecord CreateFromDb(
        AuditRecordHeading<Document> heading,
        AuditRecordChange<Id<DocumentStatus>> change,
        DocumentStatusTransitionParameterValue[] statusTransitionParametersValues)
    {
        var result = new DocumentStatusChangedAuditRecord(heading, change, statusTransitionParametersValues);

        return result;
    }
}
