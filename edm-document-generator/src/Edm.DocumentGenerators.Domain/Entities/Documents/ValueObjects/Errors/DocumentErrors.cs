using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesErrors;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Errors;

public sealed class DocumentErrors
{
    internal DocumentErrors(string[] errors, DocumentAttributeError[] attributesErrors)
    {
        Errors = errors;
        AttributesErrors = attributesErrors;
    }

    public string[] Errors { get; }
    public DocumentAttributeError[] AttributesErrors { get; }

    public bool HasErrors => AttributesErrors.Length != 0 || Errors.Length != 0;
}
