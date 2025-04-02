using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Contexts;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.StatusChanges;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses.StatusChanged;

public sealed record DocumentStatusChangedEventArgs(DocumentEventContext Context, DocumentStatusChange Change)
    : DocumentEventArgs<DocumentEventContext>(Context);
