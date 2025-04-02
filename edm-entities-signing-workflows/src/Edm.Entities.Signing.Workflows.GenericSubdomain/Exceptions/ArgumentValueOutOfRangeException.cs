using System.Runtime.CompilerServices;

namespace Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;

public sealed class ArgumentValueOutOfRangeException : ArgumentOutOfRangeException
{
    public ArgumentValueOutOfRangeException(object actualValue, [CallerArgumentExpression("actualValue")] string? paramName = null)
        : base(paramName, actualValue, $"Argument (name: {paramName}, value: {actualValue}) is not supported.")
    {
    }
}
