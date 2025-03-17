using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Contexts;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.AttributesChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.StatusChanges;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Changed;

public sealed record DocumentChangedEventArgs(
    DocumentEventContext Context,
    DocumentStatusChange? StatusChange,
    DocumentAttributesChange? AttributesChange)
    : DocumentEventArgs<DocumentEventContext>(Context);
