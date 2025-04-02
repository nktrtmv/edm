namespace Edm.DocumentGenerator.Gateway.Core.Domains;

public sealed record DocumentsSettingsBff(bool DisableManualCreation, string RegistryTitle, string DetailsTitle, string CreationTitle);
