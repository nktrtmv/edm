using System.Runtime.CompilerServices;

namespace Edm.DocumentGenerators.GenericSubdomain.Exceptions;

public sealed class ArgumentTypeOutOfRangeException : ArgumentOutOfRangeException
{
    public ArgumentTypeOutOfRangeException(object? actualValue, [CallerArgumentExpression("actualValue")] string? paramName = null)
        : base(paramName, actualValue, $"Argument (name: {paramName}, type: {actualValue?.GetType().FullName ?? "NULL"}) is not supported.")
    {
    }

    public ArgumentTypeOutOfRangeException(Enum actualValue, [CallerArgumentExpression("actualValue")] string? paramName = null)
        : base(paramName, actualValue, $"Enum argument (name: {paramName}, value ({actualValue}) is not supported.")
    {
    }
}
