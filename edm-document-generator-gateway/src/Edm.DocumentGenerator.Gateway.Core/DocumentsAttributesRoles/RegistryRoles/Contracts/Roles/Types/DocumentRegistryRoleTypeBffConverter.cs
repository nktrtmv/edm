using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Types.Inheritors;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Types.Inheritors.DisplayTypes;
using Edm.DocumentGenerator.Gateway.ExternalServices;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types.Inheritors.Booleans;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types.Inheritors.Dates;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types.Inheritors.Numbers;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types.Inheritors.References;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types.Inheritors.Strings;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Types;

internal static class DocumentRegistryRoleTypeBffConverter
{
    public static DocumentRegistryRoleTypeBff ToBff(DocumentRegistryRoleTypeExternal role)
    {
        DocumentRegistryRoleTypeBff result = role switch
        {
            DocumentBooleanRegistryRoleTypeExternal => new DocumentBooleanRegistryRoleTypeBff(),
            DocumentDateRegistryRoleTypeExternal t => new DocumentDateRegistryRoleTypeBff
                { DisplayType = EnumConverter.ToEnum(t.DisplayType, v => (DateRegistryRoleDisplayTypeBff)v) },
            DocumentNumberRegistryRoleTypeExternal t => new DocumentNumberRegistryRoleTypeBff { Precision = t.Precision },
            DocumentReferenceRegistryRoleTypeExternal t => new DocumentReferenceRegistryRoleTypeBff
            {
                ReferenceType = t.ReferenceType,
                DisplayType = EnumConverter.ToEnum(t.DisplayType, v => (ReferenceRegistryRoleDisplayTypeBff)v)
            },
            DocumentStringRegistryRoleTypeExternal => new DocumentStringRegistryRoleTypeBff(),
            _ => throw new ArgumentTypeOutOfRangeException(role)
        };

        return result;
    }
}
