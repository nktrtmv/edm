using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Attachments;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Booleans;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Dates;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Numbers;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Strings;
using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsSystemAttributes.Queries.GetAll.Contracts.Attributes;

internal static class DocumentSystemAttributeBffConverter
{
    internal static DocumentAttributeBff FromDto(DomainRoles domainRoles, DocumentSystemAttributeDto attribute)
    {
        var result = attribute.ValueCase switch
        {
            DocumentSystemAttributeDto.ValueOneofCase.AsAttachment => new DocumentAttachmentAttributeBff(),
            DocumentSystemAttributeDto.ValueOneofCase.AsBoolean => new DocumentBooleanAttributeBff(),
            DocumentSystemAttributeDto.ValueOneofCase.AsDate => new DocumentDateAttributeBff(),
            DocumentSystemAttributeDto.ValueOneofCase.AsNumber => ToNumberBff(attribute.AsNumber),
            DocumentSystemAttributeDto.ValueOneofCase.AsReference => ToReferenceBff(attribute.AsReference),
            DocumentSystemAttributeDto.ValueOneofCase.AsString => new DocumentStringAttributeBff(),
            _ => throw new ArgumentTypeOutOfRangeException(attribute.ValueCase)
        };

        result.Id = attribute.Data.Id;
        result.IsArray = attribute.Data.IsArray;
        result.SystemName = attribute.Data.SystemName;
        result.DisplayName = attribute.Data.DisplayName;
        result.RegistryRoles = attribute.Data.RegistryRolesIds.Select(domainRoles.GetRegistryRoleNameById).ToArray();
        result.DocumentsRoles = attribute.Data.DocumentRolesIds.Select(domainRoles.GetDocumentRoleNameById).ToArray();

        return result;
    }

    private static DocumentAttributeBff ToNumberBff(DocumentNumberSystemAttributeDto attribute)
    {
        var result = new DocumentNumberAttributeBff
        {
            Precision = attribute.Precision
        };

        return result;
    }

    private static DocumentAttributeBff ToReferenceBff(DocumentReferenceSystemAttributeDto attribute)
    {
        var result = new DocumentReferenceAttributeBff
        {
            ReferenceType = attribute.ReferenceType
        };

        return result;
    }
}
