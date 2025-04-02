using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.
    CommentsWithAttachments;

public sealed class DocumentCommentWithAttachmentsStatusTransitionParameterValue : DocumentStatusTransitionParameterValue
{
    public DocumentCommentWithAttachmentsStatusTransitionParameterValue(
        DocumentStatusTransitionParameter parameter,
        string comment,
        Id<Attachment>[] attachmentsIds) : base(parameter)
    {
        Comment = comment;
        AttachmentsIds = attachmentsIds;
    }

    public string Comment { get; }
    public Id<Attachment>[] AttachmentsIds { get; }

    public override string ToString()
    {
        string attachmentsIds = string.Join<Id<Attachment>>(", ", AttachmentsIds);

        return $"{{ {BaseToString()}, Comment: {Comment}, AttachmentsIds: [{attachmentsIds}] }}";
    }
}
