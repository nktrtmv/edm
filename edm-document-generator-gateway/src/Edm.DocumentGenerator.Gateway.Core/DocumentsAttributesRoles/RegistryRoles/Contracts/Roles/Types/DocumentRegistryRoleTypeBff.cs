using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Types.Discriminator;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Types.Inheritors;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Types;

[DiscriminatorType<DocumentRegistryRoleTypeBffDiscriminator>]
[JsonDerivedType(typeof(DocumentBooleanRegistryRoleTypeBff), nameof(DocumentRegistryRoleTypeBffDiscriminator.Boolean))]
[JsonDerivedType(typeof(DocumentDateRegistryRoleTypeBff), nameof(DocumentRegistryRoleTypeBffDiscriminator.Date))]
[JsonDerivedType(typeof(DocumentNumberRegistryRoleTypeBff), nameof(DocumentRegistryRoleTypeBffDiscriminator.Number))]
[JsonDerivedType(typeof(DocumentReferenceRegistryRoleTypeBff), nameof(DocumentRegistryRoleTypeBffDiscriminator.Reference))]
[JsonDerivedType(typeof(DocumentStringRegistryRoleTypeBff), nameof(DocumentRegistryRoleTypeBffDiscriminator.String))]
public abstract class DocumentRegistryRoleTypeBff;
