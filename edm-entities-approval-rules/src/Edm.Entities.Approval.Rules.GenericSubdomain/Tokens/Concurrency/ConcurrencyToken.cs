using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

public readonly record struct ConcurrencyToken<T>
{
    internal const string OutputStringFormat = "o";

    internal ConcurrencyToken(UtcDateTime<T> value)
    {
        Value = value;
    }

    public UtcDateTime<T> Value { get; }

    public static ConcurrencyToken<T> Empty { get; } = new ConcurrencyToken<T>(new UtcDateTime<T>(DateTime.MinValue));

    public void AssertEqualsTo(ConcurrencyToken<T> other)
    {
        if (Value != other.Value)
        {
            throw new OptimisticConcurrencyException();
        }
    }
}
