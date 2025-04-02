namespace Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

public sealed class BusinessLogicApplicationException : ApplicationException
{
    public BusinessLogicApplicationException(string? message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
