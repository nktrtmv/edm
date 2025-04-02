namespace Edm.Document.Classifier.Domain;

public sealed class EmptyReference : ITypedReference
{
    private EmptyReference()
    {
    }

    public static readonly EmptyReference Instance = new EmptyReference();
}
