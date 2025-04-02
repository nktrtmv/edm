namespace Edm.DocumentGenerators.Domain.ValueObjects.Parameters.Factories;

public static class DocumentParametersFactory
{
    public static DocumentParameters CreateNew()
    {
        var result = new DocumentParameters(false);

        return result;
    }
}
