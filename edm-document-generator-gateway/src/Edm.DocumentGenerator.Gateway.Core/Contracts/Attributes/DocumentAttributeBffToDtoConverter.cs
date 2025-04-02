using Edm.DocumentGenerators.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

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

internal static class DocumentAttributeBffToDtoConverter
{
    internal static DocumentAttributeDto ToDto(DocumentAttributeBff attribute, DomainRoles domainRoles)
    {
        var result = attribute switch
        {
            DocumentAttachmentAttributeBff a => ToAttachment(a),
            DocumentBooleanAttributeBff a => ToBoolean(a),
            DocumentDateAttributeBff a => ToDate(a),
            DocumentNumberAttributeBff a => ToNumber(a),
            DocumentReferenceAttributeBff a => ToReference(a),
            DocumentStringAttributeBff a => ToString(a),
            DocumentTupleAttributeBff a => ToTuple(a, domainRoles),
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        var data = ToData(attribute, domainRoles);

        result.Data = data;

        return result;
    }

    private static DocumentAttributeDto ToAttachment(DocumentAttachmentAttributeBff attribute)
    {
        string[] defaultValues = attribute.DefaultValues;

        var asAttachment = new DocumentAttachmentAttributeDto
        {
            DefaultValues = { defaultValues }
        };

        var result = new DocumentAttributeDto
        {
            AsAttachment = asAttachment
        };

        return result;
    }

    private static DocumentAttributeDto ToBoolean(DocumentBooleanAttributeBff attribute)
    {
        var defaultValues = attribute.DefaultValues;

        var asBoolean = new DocumentBooleanAttributeDto
        {
            DefaultValues = { defaultValues }
        };

        var result = new DocumentAttributeDto
        {
            AsBoolean = asBoolean
        };

        return result;
    }

    private static DocumentAttributeDto ToDate(DocumentDateAttributeBff attribute)
    {
        Timestamp[] defaultValues = attribute.DefaultValues.Select(Timestamp.FromDateTime).ToArray();

        var asDate = new DocumentDateAttributeDto
        {
            DefaultValues = { defaultValues }
        };

        var result = new DocumentAttributeDto
        {
            AsDate = asDate
        };

        return result;
    }

    private static DocumentAttributeDto ToNumber(DocumentNumberAttributeBff attribute)
    {
        var defaultValues = attribute.DefaultValues;

        var asNumber = new DocumentNumberAttributeDto
        {
            Precision = attribute.Precision,
            DefaultValues = { defaultValues }
        };

        var result = new DocumentAttributeDto
        {
            AsNumber = asNumber
        };

        return result;
    }

    private static DocumentAttributeDto ToReference(DocumentReferenceAttributeBff attribute)
    {
        string[] defaultValues = attribute.DefaultValues;

        var asReference = new DocumentReferenceAttributeDto
        {
            ReferenceType = attribute.ReferenceType,
            DefaultValues = { defaultValues }
        };

        var result = new DocumentAttributeDto
        {
            AsReference = asReference
        };

        return result;
    }

    private static DocumentAttributeDto ToString(DocumentStringAttributeBff attribute)
    {
        string[] defaultValues = attribute.DefaultValues;

        var asString = new DocumentStringAttributeDto
        {
            DefaultValues = { defaultValues }
        };

        var result = new DocumentAttributeDto
        {
            AsString = asString
        };

        return result;
    }

    private static DocumentAttributeDto ToTuple(DocumentTupleAttributeBff attribute, DomainRoles domainRoles)
    {
        DocumentAttributeDto[] innerAttributes = attribute.InnerAttributes.Select(x => ToDto(x, domainRoles)).ToArray();

        var asTuple = new DocumentTupleAttributeDto
        {
            InnerAttributes = { innerAttributes }
        };

        var result = new DocumentAttributeDto
        {
            AsTuple = asTuple
        };

        return result;
    }

    private static DocumentAttributeDataDto ToData(DocumentAttributeBff attribute, DomainRoles domainRoles)
    {
        DocumentAttributePermissionDto[] permissions =
            attribute.Permissions.Select(DocumentAttributePermissionBffConverter.ToDto).ToArray();

        var documentsRoles = attribute.DocumentsRoles.Select(domainRoles.GetDocumentRoleIdByName).ToArray();

        var registryRoles = attribute.RegistryRoles.Select(domainRoles.GetRegistryRoleIdByName).ToArray();

        var result = new DocumentAttributeDataDto
        {
            Id = attribute.Id,
            IsArray = attribute.IsArray,
            FrontMetadata = attribute.FrontMetadata,
            IsApprovalParticipant = attribute.IsApprovalParticipant,
            Permissions = { permissions },
            DocumentsRoles = { documentsRoles },
            RegistryRoles = { registryRoles },
            SystemName = attribute.SystemName,
            DisplayName = attribute.DisplayName
        };

        return result;
    }
}
