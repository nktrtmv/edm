namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public sealed class RegistrySettings
{
    private RegistrySettings()
    {
    }

    public bool ShowInRegistry { get; private set; }
    public bool ShowByDefault { get; private set; }

    public static RegistrySettings Parse(
        bool showInRegistry,
        bool showByDefault)
    {
        return new RegistrySettings
        {
            ShowInRegistry = showInRegistry,
            ShowByDefault = showByDefault,
        };
    }
}
