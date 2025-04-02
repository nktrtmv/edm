namespace Edm.Document.Classifier.Infrastructure.Repositories.Domains.Contracts;

public sealed class UnvalidatedDocumentsSettings
{
    public bool DisableManualCreation { get; set; }

    public string? RegistryTitle { get; set; }

    public string? DetailsTitle { get; set; }

    public string? CreationTitle { get; set; }
}
