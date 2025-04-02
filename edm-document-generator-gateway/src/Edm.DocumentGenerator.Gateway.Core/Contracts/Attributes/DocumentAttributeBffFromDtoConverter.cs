using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Attachments;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Booleans;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Dates;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Numbers;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Strings;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Tuples;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Permissions;
using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes;

internal static class DocumentAttributeBffFromDtoConverter
{
    internal static DocumentAttributeBff FromDto(DocumentAttributeDto attribute, DomainRoles domainRoles)
    {
        var result = attribute.ValueCase switch
        {
            DocumentAttributeDto.ValueOneofCase.AsAttachment => ToAttachment(attribute.AsAttachment),
            DocumentAttributeDto.ValueOneofCase.AsBoolean => ToBoolean(attribute.AsBoolean),
            DocumentAttributeDto.ValueOneofCase.AsDate => ToDate(attribute.AsDate),
            DocumentAttributeDto.ValueOneofCase.AsNumber => ToNumber(attribute.AsNumber),
            DocumentAttributeDto.ValueOneofCase.AsReference => ToReference(attribute.AsReference),
            DocumentAttributeDto.ValueOneofCase.AsString => ToString(attribute.AsString),
            DocumentAttributeDto.ValueOneofCase.AsTuple => ToTuple(attribute.AsTuple, domainRoles),
            _ => throw new ArgumentTypeOutOfRangeException(attribute.ValueCase)
        };

        result.SetData(attribute.Data, domainRoles);

        return result;
    }

    private static DocumentAttributeBff ToDate(DocumentDateAttributeDto attribute)
    {
        var defaultValues = attribute.DefaultValues.Select(d => d.ToDateTime()).ToArray();

        var result = new DocumentDateAttributeBff
        {
            DefaultValues = defaultValues
        };

        return result;
    }

    private static DocumentAttributeBff ToBoolean(DocumentBooleanAttributeDto attribute)
    {
        var defaultValues = attribute.DefaultValues.ToArray();

        var result = new DocumentBooleanAttributeBff
        {
            DefaultValues = defaultValues
        };

        return result;
    }

    private static DocumentAttributeBff ToAttachment(DocumentAttachmentAttributeDto attribute)
    {
        string[] defaultValues = attribute.DefaultValues.ToArray();

        var result = new DocumentAttachmentAttributeBff
        {
            DefaultValues = defaultValues
        };

        return result;
    }

    private static DocumentAttributeBff ToString(DocumentStringAttributeDto attribute)
    {
        string[] defaultValues = attribute.DefaultValues.ToArray();

        var result = new DocumentStringAttributeBff
        {
            DefaultValues = defaultValues
        };

        return result;
    }

    private static DocumentAttributeBff ToNumber(DocumentNumberAttributeDto attribute)
    {
        var defaultValues = attribute.DefaultValues.ToArray();

        var result = new DocumentNumberAttributeBff
        {
            Precision = attribute.Precision,
            DefaultValues = defaultValues
        };

        return result;
    }

    private static DocumentAttributeBff ToReference(DocumentReferenceAttributeDto attribute)
    {
        string[] defaultValues = attribute.DefaultValues.ToArray();

        var result = new DocumentReferenceAttributeBff
        {
            ReferenceType = attribute.ReferenceType,
            DefaultValues = defaultValues
        };

        return result;
    }

    private static DocumentAttributeBff ToTuple(DocumentTupleAttributeDto attribute, DomainRoles domainRoles)
    {
        DocumentAttributeBff[] innerAttributes = attribute.InnerAttributes.Select(x => FromDto(x, domainRoles)).ToArray();

        var result = new DocumentTupleAttributeBff
        {
            InnerAttributes = innerAttributes
        };

        return result;
    }

    private static void SetData<T>(this T attribute, DocumentAttributeDataDto data, DomainRoles domainRoles)
        where T : DocumentAttributeBff
    {
        DocumentAttributePermissionBff[] permissions =
            data.Permissions.Select(DocumentAttributePermissionBffConverter.FromDto).ToArray();

        string[] documentsRoles = data.DocumentsRoles.Select(domainRoles.GetDocumentRoleNameById).ToArray();
        string[] registryRoles = data.RegistryRoles.Select(domainRoles.GetRegistryRoleNameById).ToArray();

        attribute.Id = data.Id;
        attribute.IsArray = data.IsArray;
        attribute.FrontMetadata = data.FrontMetadata;
        attribute.IsApprovalParticipant = data.IsApprovalParticipant;
        attribute.Permissions = permissions;
        attribute.DocumentsRoles = documentsRoles;
        attribute.RegistryRoles = registryRoles;
        attribute.SystemName = data.SystemName;
        attribute.DisplayName = data.DisplayName;
    }
}
