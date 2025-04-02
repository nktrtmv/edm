using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues.Inheritors.
    CommentsWithAttachments;

public sealed class DocumentCommentWithAttachmentsStatusTransitionParameterValueInternal : DocumentStatusTransitionParameterValueInternal
{
    public DocumentCommentWithAttachmentsStatusTransitionParameterValueInternal(string comment, Id<DocumentAttachmentInternal>[] attachmentsIds)
    {
        Comment = comment;
        AttachmentsIds = attachmentsIds;
    }

    public string Comment { get; }
    public Id<DocumentAttachmentInternal>[] AttachmentsIds { get; }
}
