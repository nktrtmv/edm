using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Attachments;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Booleans;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Dates;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Numbers;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Strings;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Tuples;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Permissions;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes;

[DiscriminatorType<DocumentAttributeBffType>]
[JsonDerivedType(typeof(DocumentAttachmentAttributeBff), nameof(DocumentAttributeBffType.Attachment))]
[JsonDerivedType(typeof(DocumentBooleanAttributeBff), nameof(DocumentAttributeBffType.Boolean))]
[JsonDerivedType(typeof(DocumentDateAttributeBff), nameof(DocumentAttributeBffType.Date))]
[JsonDerivedType(typeof(DocumentNumberAttributeBff), nameof(DocumentAttributeBffType.Number))]
[JsonDerivedType(typeof(DocumentReferenceAttributeBff), nameof(DocumentAttributeBffType.Reference))]
[JsonDerivedType(typeof(DocumentStringAttributeBff), nameof(DocumentAttributeBffType.String))]
[JsonDerivedType(typeof(DocumentTupleAttributeBff), nameof(DocumentAttributeBffType.Tuple))]
public abstract class DocumentAttributeBff
{
    public string Id { get; set; } = string.Empty;

    public bool IsArray { get; set; }

    public string FrontMetadata { get; set; } = string.Empty;

    public bool IsApprovalParticipant { get; set; }

    public DocumentAttributePermissionBff[] Permissions { get; set; } = [];

    public string[] DocumentsRoles { get; set; } = [];

    public string[] RegistryRoles { get; set; } = [];

    public string SystemName { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;
}
