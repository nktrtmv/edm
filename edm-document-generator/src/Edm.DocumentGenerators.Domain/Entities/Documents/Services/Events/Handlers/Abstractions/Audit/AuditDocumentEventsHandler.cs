using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Contexts;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributesValuesChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses.StatusChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.StatusChanged.Factories;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Factories;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.Audit;

public abstract class AuditDocumentEventsHandler<TEventArgs> : EventsHandlerGeneric<TEventArgs>
    where TEventArgs : DocumentEventArgs<DocumentEventContext>
{
    public override void Handle(TEventArgs args)
    {
        AuditRecord<Document> record = CreateNewAuditRecord(args);

        Document document = args.Context.Host;

        Audit<Document> audit = AuditFactory<Document>.CreateFrom(document.Audit, record);

        document.SetAudit(audit);
    }

    private AuditRecord<Document> CreateNewAuditRecord(TEventArgs args)
    {
        AuditRecord<Document> result = args switch
        {
            DocumentAttributesValuesChangedEventArgs a =>
                DocumentAttributesValuesChangedAuditRecordFactory.CreateFrom(a),

            DocumentStatusChangedEventArgs a =>
                DocumentStatusChangedAuditRecordFactory.CreateFrom(a),

            _ => throw new ArgumentTypeOutOfRangeException(args)
        };

        return result;
    }
}
