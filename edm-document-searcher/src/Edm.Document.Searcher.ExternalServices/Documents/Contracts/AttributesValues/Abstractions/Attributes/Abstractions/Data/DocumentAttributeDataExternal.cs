namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Abstractions.Data;

public readonly record struct DocumentAttributeDataExternal(
    string Id,
    bool IsArray,
    int[] RegistryRolesIds,
    string SystemName,
    string DisplayName,
    int[] DocumentsRoles);
