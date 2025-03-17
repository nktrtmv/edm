using System.Collections.Concurrent;
using System.Reflection;
using System.Text.Json;

using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.Values;
using Edm.Document.Classifier.Domain;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.GetReferenceValuesSearch.Contracts.Values;

internal static class ReferenceValueDtoConverter
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertiesByType = [];

    internal static ReferenceValueDto FromInternal(DocumentReferenceValueInternal value)
    {
        var typedReference = value.TypedReference;
        PropertyInfo[] properties = PropertiesByType.GetOrAdd(typedReference.GetType(), GetPropertiesByType);

        Dictionary<string, string?> arguments = properties
            .Select(x => (x.Name, Value: GetValue(x, typedReference)))
            .ToDictionary(x => x.Name, x => x.Value);

        var result = new ReferenceValueDto
        {
            Id = value.Id,
            DisplayValue = value.DisplayValue,
            DisplaySubValue = value.DisplaySubValue,
            Arguments = { arguments.Where(x => x.Value != null).ToDictionary(x => x.Key, x => x.Value) }
        };

        return result;
    }

    private static PropertyInfo[] GetPropertiesByType(Type typeToScan) =>
        typeToScan.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

    private static string? GetValue(PropertyInfo property, ITypedReference? typedReference)
    {
        object? value = property.GetValue(typedReference);

        if (property.PropertyType == typeof(string[]) && value is not null)
        {
            return JsonSerializer.Serialize(value);
        }

        return value?.ToString();
    }
}
