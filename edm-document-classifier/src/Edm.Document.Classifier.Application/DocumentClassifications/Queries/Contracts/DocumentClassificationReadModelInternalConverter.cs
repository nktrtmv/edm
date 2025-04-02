using Edm.Document.Classifier.Application.DocumentClassifications.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Queries.Contracts;

internal static class DocumentClassificationReadModelInternalConverter
{
    public static DocumentClassificationReadModelInternal FromDomain(DocumentClassification classification)
    {
        var templateId = IdConverterTo.ToString(classification.DocumentTemplateId);

        DocumentClassifierSubsetInternal subset = ClassifierPatternInternalConverter.FromDomain(classification.DocumentClassifierSubset);

        var response = new DocumentClassificationReadModelInternal(
            templateId,
            classification.Name,
            subset);

        return response;
    }
}
