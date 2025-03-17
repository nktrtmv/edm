namespace Edm.Document.Classifier.GenericSubdomain.Extensions.Exceptions;

public static class ExceptionExceptions
{
    public static IEnumerable<Exception> SelectWithInnerExceptions(Exception exception)
    {
        for (Exception? e = exception; e is not null; e = e.InnerException)
        {
            yield return e;
        }
    }
}
