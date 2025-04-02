namespace Edm.Document.Classifier.GenericSubdomain.Exceptions;

public sealed class UnsupportedTypeException<T> : ArgumentException
{
    public UnsupportedTypeException()
        : base($"Unsupported (type: {typeof(T)}).")
    {
    }
}
