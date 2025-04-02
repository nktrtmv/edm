namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;

public sealed record DocumentSettingsInternal(
    bool DisableManualCreation,
    string RegistryTitle,
    string DetailsTitle,
    string CreationTitle);
