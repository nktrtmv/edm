namespace Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts.SystemAttributes.Abstractions.Data;

public sealed record DocumentSystemAttributeDataInternal(
    string Id,
    bool IsArray,
    string SystemName,
    string DisplayName,
    int[] RegistryRolesIds,
    int[] DocumentRolesIds);
