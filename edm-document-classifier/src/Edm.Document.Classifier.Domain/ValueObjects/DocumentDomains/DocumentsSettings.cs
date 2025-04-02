namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct DocumentsSettings(bool DisableManualCreation, DisplayName RegistryTitle, DisplayName DetailsTitle, DisplayName CreationTitle);
