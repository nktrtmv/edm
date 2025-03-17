using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Signing.Workflows.GenericSubdomain.Tokens.Concurrency;

public readonly record struct ConcurrencyToken<T>
{
    internal const string OutputStringFormat = "o";

    internal ConcurrencyToken(UtcDateTime<T> value)
    {
        Value = value;
    }

    internal UtcDateTime<T> Value { get; }

    public static ConcurrencyToken<T> Empty { get; } = new ConcurrencyToken<T>(new UtcDateTime<T>(DateTime.MinValue));

    public void AssertEqualsTo(ConcurrencyToken<T> other)
    {
        if (Value != other.Value)
        {
            throw new OptimisticConcurrencyException();
        }
    }
}
