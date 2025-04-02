using System.Runtime.CompilerServices;

using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Services.Selectors;

internal record DocumentAttributeSelector<T>
{
    internal int? Role { get; init; }
    internal string[] DisplayNames { get; init; } = [];
    internal string[] SystemNames { get; init; } = [];

    internal bool IsMatched(DocumentAttribute attribute)
    {
        if (!AttributeMatched(attribute))
        {
            return false;
        }

        if (attribute is not T typedAttribute)
        {
            throw new UnsupportedTypeArgumentException<T>(attribute);
        }

        if (!AttributeTypeMatched(typedAttribute))
        {
            return false;
        }

        return true;
    }

    private bool AttributeMatched(DocumentAttribute attribute)
    {
        if (DisplayNames.Contains(attribute.DisplayName, StringComparer.OrdinalIgnoreCase))
        {
            return true;
        }

        if (SystemNames.Contains(attribute.SystemName?.Value, StringComparer.OrdinalIgnoreCase))
        {
            return true;
        }

        if (Role is not null && attribute.Data.DocumentsRoles.Contains(Role.Value))
        {
            return true;
        }

        return false;
    }

    protected virtual bool AttributeTypeMatched(T attribute)
    {
        return true;
    }

    private static string? FormatValuesValue(string[] values)
    {
        if (!values.Any())
        {
            return null;
        }

        if (values.Length == 1)
        {
            return values.Single();
        }

        string result = string.Join(", ", values);

        return result;
    }

    private static string? FormatValues(string[] values, [CallerArgumentExpression(nameof(values))] string? prefix = null)
    {
        string? value = FormatValuesValue(values);

        if (value is null)
        {
            return null;
        }

        var result = $"{prefix}: {value}";

        return result;
    }

    protected virtual IEnumerable<string?> GetMarkers()
    {
        var type = $"Type: {typeof(T).Namespace}";

        string? role = Role is null ? null : $"Role: {Role}";

        string? displayNames = FormatValues(DisplayNames);

        string? systemNames = FormatValues(SystemNames);

        string?[] result = { type, role, displayNames, systemNames };

        return result;
    }

    public override string ToString()
    {
        IEnumerable<string> markers = GetMarkers()
            .OfType<string>();

        string markersList = string.Join(", ", markers);

        var result = $"{{ {markersList} }}";

        return result;
    }
}
