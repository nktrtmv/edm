using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesErrors;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Errors.Factories;

public static class DocumentErrorsFactory
{
    public static DocumentErrors CreateNew()
    {
        var result = new DocumentErrors([], []);

        return result;
    }

    public static DocumentErrors CreateFrom(string[] errors, DocumentAttributeError[] attributesErrors)
    {
        var result = new DocumentErrors(errors, attributesErrors);

        return result;
    }
}
