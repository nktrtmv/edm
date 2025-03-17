using System.Diagnostics.CodeAnalysis;

using JetBrains.Annotations;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed;

// ReSharper disable UnusedMember.Global

namespace Edm.DocumentGenerator.Gateway.Core.Validators;

[SuppressMessage("ReSharper", "ArrangeMethodOrOperatorBody")]
public static class DocumentExtensions
{
    public static bool HasNonEmptyReferenceWithWithRole(this DocumentDetailedBff document, string roleName)
    {
        var attribute = document.GetAttributeWithRole<DocumentReferenceAttributeValueDetailedBff>(roleName);

        return attribute != null && attribute.Values.Any(x => !string.IsNullOrWhiteSpace(x.Id));
    }

    public static bool HasAttributeValueWithRole<T>(this DocumentDetailedBff document, string roleName)
        where T : DocumentAttributeValueDetailedBff => document.GetAttributeWithRole<T>(roleName) != null;

    public static bool HasValueWithRoleAndCondition<T>(
        this DocumentDetailedBff document,
        string role,
        Func<T, bool> predicate)
        where T : DocumentAttributeValueDetailedBff
    {
        var parameter = document.GetAttributeWithRole<T>(role);

        return parameter != null && predicate(parameter);
    }

    public static T? GetAttributeValueWithRole<T>(this DocumentDetailedBff document, string roleName, RequireStruct<T>? _ = null) where T : struct
    {
        var attributeValue = document.GetAttributeWithRole<DocumentAttributeValueGenericDetailedBff<T>>(roleName);

        var result = GetFirstValue(attributeValue);

        return result;
    }

    public static T? GetAttributeValueWithRole<T>(this DocumentDetailedBff document, string roleName, RequireClass<T>? _ = null) where T : class
    {
        var attributeValue = document.GetAttributeWithRole<DocumentAttributeValueGenericDetailedBff<T>>(roleName);

        var result = GetFirstValue(attributeValue);

        return result;
    }

    public static T? GetAttributeValueWithSystemName<T>(this DocumentDetailedBff document, string systemName, RequireClass<T>? _ = null) where T : class
    {
        var attributeValue = document.GetAttributeWithSystemName<DocumentAttributeValueGenericDetailedBff<T>>(systemName);

        var result = GetFirstValue(attributeValue);

        return result;
    }

    public static T? GetAttributeValueWithSystemName<T>(this DocumentAttributeValueDetailedBff[] attributes, string systemName, RequireClass<T>? _ = null) where T : class
    {
        var attributeValue = attributes.GetAttributeWithSystemName<DocumentAttributeValueGenericDetailedBff<T>>(systemName);

        var result = GetFirstValue(attributeValue);

        return result;
    }

    public static T? GetAttributeValueWithSystemName<T>(this DocumentAttributeValueDetailedBff[] attributes, string systemName, RequireStruct<T>? _ = null)
        where T : struct
    {
        var attributeValue = attributes.GetAttributeWithSystemName<DocumentAttributeValueGenericDetailedBff<T>>(systemName);

        var result = GetFirstValue(attributeValue);

        return result;
    }

    public static T? GetAttributeValueWithReferenceType<T>(this DocumentAttributeValueDetailedBff[] attributes, string referenceType, RequireClass<T>? _ = null)
        where T : class
    {
        var attributeValue = attributes.GetAttributeWithReferenceType<DocumentAttributeValueGenericDetailedBff<T>>(referenceType);

        var result = GetFirstValue(attributeValue);

        return result;
    }

    private static T? GetFirstValue<T>(DocumentAttributeValueGenericDetailedBff<T>? attributeValue, RequireStruct<T>? _ = null) where T : struct
    {
        if (attributeValue is null)
        {
            return null;
        }

        var values = attributeValue.Values;

        if (values.Length == 0)
        {
            return null;
        }

        var result = values.First();

        return result;
    }

    private static T? GetFirstValue<T>(DocumentAttributeValueGenericDetailedBff<T>? attributeValue, RequireClass<T>? _ = null) where T : class
    {
        if (attributeValue is null)
        {
            return null;
        }

        T[] values = attributeValue.Values;

        if (values.Length == 0)
        {
            return null;
        }

        var result = values.First();

        return result;
    }

    public static T GetRequiredAttributeWithRole<T>(this DocumentDetailedBff document, string roleName) where T : DocumentAttributeValueDetailedBff
    {
        var attributeValue = document.GetAttributeWithRole<T>(roleName);

        ArgumentNullException.ThrowIfNull(attributeValue);

        return attributeValue;
    }

    public static T? GetAttributeWithRole<T>(this DocumentDetailedBff document, string roleName) where T : DocumentAttributeValueDetailedBff =>
        document.AttributesValues.OfType<T>().FirstOrDefault(x => x.Attribute.DocumentsRoles.Contains(roleName));

    public static T? GetAttributeWithSystemName<T>(this DocumentDetailedBff document, string systemName) where T : DocumentAttributeValueDetailedBff =>
        document.AttributesValues.GetAttributeWithSystemName<T>(systemName);

    public static T? GetAttributeWithSystemName<T>(this DocumentAttributeValueDetailedBff[] attributesValues, string systemName)
        where T : DocumentAttributeValueDetailedBff =>
        attributesValues.OfType<T>().FirstOrDefault(x => x.Attribute.SystemName.Equals(systemName, StringComparison.OrdinalIgnoreCase));

    public static T? GetAttributeWithReferenceType<T>(this DocumentAttributeValueDetailedBff[] attributesValues, string referenceType)
        where T : DocumentAttributeValueDetailedBff => attributesValues.OfType<T>()
        .FirstOrDefault(x => x.Attribute is DocumentReferenceAttributeBff referenceAttributeBff && referenceAttributeBff.ReferenceType == referenceType);

    public static bool HasValue(this DocumentReferenceAttributeValueDetailedBff reference, string valueToSearch) => reference.Values.Any(x => x.Id == valueToSearch);

    [UsedImplicitly]

    // ReSharper disable once UnusedTypeParameter
    public sealed class RequireStruct<T> where T : struct
    {
    }

    [UsedImplicitly]

    // ReSharper disable once UnusedTypeParameter
    public sealed class RequireClass<T> where T : class
    {
    }
}
