using Edm.Document.Classifier.Application;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Booleans;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Dates;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Numbers;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.References;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Strings;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain.Exceptions;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Contracts.Roles.Types;

internal static class DocumentRegistryRoleTypeDtoFromInternalConverter
{
    internal static DocumentRegistryRoleTypeDto FromInternal(DomainRegistryRoleInternal role, DocumentRegistryRoleTypeInternal type)
    {
        DocumentRegistryRoleTypeDto result = type switch
        {
            BooleanDocumentRegistryRoleTypeInternal => ToBoolean(),
            DateDocumentRegistryRoleTypeInternal t => ToDate(t),
            NumberDocumentRegistryRoleTypeInternal t => ToNumber(t),
            ReferenceDocumentRegistryRoleTypeInternal t => ToReference(t),
            StringDocumentRegistryRoleTypeInternal => ToString(),
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        result.FilterSettings = new DocumentRegistryRoleFilterSettingsTypeDto
        {
            AllowForSearch = role.FilterSettings.AllowForSearch,
            ShowInFilters = role.FilterSettings.ShowInFilters,
            AllowMultipleValues = role.FilterSettings.AllowMultipleValues,
            SearchKind = (SearchKindDto)(role.FilterSettings.SearchKind ?? SearchKind.None),
            Order = role.FilterSettings.Order
        };

        result.RegistrySettings = new DocumentRegistryRoleRegistrySettingsTypeDto
        {
            ShowInRegistry = role.RegistrySettings.ShowInRegistry,
            ShowByDefault = role.RegistrySettings.ShowByDefault
        };

        return result;
    }

    private static DocumentRegistryRoleTypeDto ToBoolean()
    {
        var asBoolean = new DocumentBooleanRegistryRoleTypeDto();

        var result = new DocumentRegistryRoleTypeDto
        {
            AsBoolean = asBoolean
        };

        return result;
    }

    private static DocumentRegistryRoleTypeDto ToDate(DateDocumentRegistryRoleTypeInternal type)
    {
        DateRegistryRoleDisplayTypeDto displayType = type.DisplayType switch
        {
            DateRegistryRoleDisplayType.Date => DateRegistryRoleDisplayTypeDto.Date,
            DateRegistryRoleDisplayType.DateTime => DateRegistryRoleDisplayTypeDto.DateTime,
            DateRegistryRoleDisplayType.DueDate => DateRegistryRoleDisplayTypeDto.DueDate,
            _ => throw new ArgumentTypeOutOfRangeException(type.DisplayType)
        };

        var asDate = new DocumentDateRegistryRoleTypeDto
        {
            DisplayType = displayType
        };

        var result = new DocumentRegistryRoleTypeDto
        {
            AsDate = asDate
        };

        return result;
    }

    private static DocumentRegistryRoleTypeDto ToNumber(NumberDocumentRegistryRoleTypeInternal type)
    {
        var asNumber = new DocumentNumberRegistryRoleTypeDto
        {
            Precision = type.Precision
        };

        var result = new DocumentRegistryRoleTypeDto
        {
            AsNumber = asNumber
        };

        return result;
    }

    private static DocumentRegistryRoleTypeDto ToReference(ReferenceDocumentRegistryRoleTypeInternal type)
    {
        string referenceType = ReferenceIdToMetadataConverter.ToMetadata(type.ReferenceId);

        var asReference = new DocumentReferenceRegistryRoleTypeDto
        {
            ReferenceType = referenceType,
            DisplayType = (ReferenceRegistryRoleDisplayTypeDto)type.DisplayType
        };

        var result = new DocumentRegistryRoleTypeDto
        {
            AsReference = asReference
        };

        return result;
    }

    private new static DocumentRegistryRoleTypeDto ToString()
    {
        var asString = new DocumentStringRegistryRoleTypeDto();

        var result = new DocumentRegistryRoleTypeDto
        {
            AsString = asString
        };

        return result;
    }
}
