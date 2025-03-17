using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.Attachments;

public sealed class DocumentAttachmentAttributeValueSelector
    : DocumentAttributeValueByRoleSelectorGeneric<AttachmentDocumentAttributeValue, DocumentAttachmentAttribute, string>
{
    public DocumentAttachmentAttributeValueSelector(DocumentAttributeDocumentRole role, params string[] displayNames) : base(role, displayNames)
    {
    }
}
