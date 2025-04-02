using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues.
    Inheritors.Comments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues.
    Inheritors.CommentsWithAttachments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues;

[DiscriminatorType<DocumentAuditStatusTransitionParameterValueBffType>]
[JsonDerivedType(
    typeof(DocumentAuditCommentStatusTransitionParameterValueBff),
    nameof(DocumentAuditStatusTransitionParameterValueBffType.Comment))]
[JsonDerivedType(
    typeof(DocumentAuditCommentWithAttachmentsStatusTransitionParameterValueBff),
    nameof(DocumentAuditStatusTransitionParameterValueBffType.CommentWithAttachments))]
public abstract class DocumentAuditStatusTransitionParameterValueBff
{
}
