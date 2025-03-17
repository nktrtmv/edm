using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Attachments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Booleans;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Dates;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Numbers;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Strings;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Tuples;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues;

[JsonDerivedType(typeof(DocumentAttachmentAttributeValueBareBff), "Attachment")]
[JsonDerivedType(typeof(DocumentBooleanAttributeValueBareBff), "Boolean")]
[JsonDerivedType(typeof(DocumentDateAttributeValueBareBff), "Date")]
[JsonDerivedType(typeof(DocumentNumberAttributeValueBareBff), "Number")]
[JsonDerivedType(typeof(DocumentReferenceAttributeValueBareBff), "Reference")]
[JsonDerivedType(typeof(DocumentStringAttributeValueBareBff), "String")]
[JsonDerivedType(typeof(DocumentTupleAttributeValueBareBff), "Tuple")]
public abstract class DocumentAttributeValueBareBff
{
    public required string Id { get; init; }
}
