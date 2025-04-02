using Edm.Document.Classifier.Application;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Booleans;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Dates;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Numbers;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.References;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Strings;
using Edm.Document.Classifier.GenericSubdomain.Exceptions;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Queries.GetAllDocumentsAttributes.Converters.DocumentsAttributes.Types;

internal static class DocumentAttributeTypeInternalToDtoConverter
{
    internal static DocumentAttributeTypeDto ToTypeDto(DomainRegistryRoleInternal type)
    {
        DocumentAttributeTypeDto result = type.Type switch
        {
            BooleanDocumentRegistryRoleTypeInternal => ToBoolean(),
            DateDocumentRegistryRoleTypeInternal => ToDate(),
            NumberDocumentRegistryRoleTypeInternal t => ToNumber(t),
            ReferenceDocumentRegistryRoleTypeInternal t => ToReference(t),
            StringDocumentRegistryRoleTypeInternal => ToString(),
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    private static DocumentAttributeTypeDto ToBoolean()
    {
        var asBoolean = new BooleanDocumentAttributeTypeDto();

        var result = new DocumentAttributeTypeDto
        {
            AsBoolean = asBoolean
        };

        return result;
    }

    private static DocumentAttributeTypeDto ToDate()
    {
        var asDate = new DateDocumentAttributeTypeDto();

        var result = new DocumentAttributeTypeDto
        {
            AsDate = asDate
        };

        return result;
    }

    private static DocumentAttributeTypeDto ToNumber(NumberDocumentRegistryRoleTypeInternal type)
    {
        var asNumber = new NumberDocumentAttributeTypeDto
        {
            Precision = type.Precision
        };

        var result = new DocumentAttributeTypeDto
        {
            AsNumber = asNumber
        };

        return result;
    }

    private static DocumentAttributeTypeDto ToReference(ReferenceDocumentRegistryRoleTypeInternal type)
    {
        var asReference = new ReferenceDocumentAttributeTypeDto
        {
            ReferenceTypeId = ReferenceIdToMetadataConverter.ToMetadata(type.ReferenceId)
        };

        var result = new DocumentAttributeTypeDto
        {
            AsReference = asReference
        };

        return result;
    }

    private new static DocumentAttributeTypeDto ToString()
    {
        var asString = new StringDocumentAttributeTypeDto();

        var result = new DocumentAttributeTypeDto
        {
            AsString = asString
        };

        return result;
    }
}
