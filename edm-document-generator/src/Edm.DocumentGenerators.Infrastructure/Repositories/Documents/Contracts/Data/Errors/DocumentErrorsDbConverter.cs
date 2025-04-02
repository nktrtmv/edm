using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesErrors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Errors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Errors.Factories;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Errors.AttributesErrors;

using Google.Protobuf.Collections;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Errors;

internal static class DocumentErrorsDbConverter
{
    internal static DocumentErrorsDb FromDomain(DocumentErrors documentErrors)
    {
        DocumentAttributeErrorDb[] attributesErrors = documentErrors.AttributesErrors.Select(DocumentAttributeErrorDbConverter.FromDomain).ToArray();

        var result = new DocumentErrorsDb
        {
            Errors = { documentErrors.Errors },
            AttributesErrors = { attributesErrors }
        };

        return result;
    }

    internal static DocumentErrors ToDomain(DocumentErrorsDb documentErrors)
    {
        string[] errors = documentErrors.Errors.ToArray();

        DocumentAttributeError[] attributesErrors = documentErrors.AttributesErrors.Select(DocumentAttributeErrorDbConverter.ToDomain).ToArray();

        DocumentErrors result = DocumentErrorsFactory.CreateFrom(errors, attributesErrors);

        return result;
    }

    public static DocumentErrors ObsoleteToDomain(RepeatedField<DocumentAttributeErrorDb>? attributesErrorsObsolete)
    {
        DocumentAttributeError[]? attributesErrors = attributesErrorsObsolete?.Select(DocumentAttributeErrorDbConverter.ToDomain).ToArray();

        if (attributesErrors is null)
        {
            return DocumentErrorsFactory.CreateNew();
        }

        DocumentErrors result = DocumentErrorsFactory.CreateFrom([], attributesErrors);

        return result;
    }
}
