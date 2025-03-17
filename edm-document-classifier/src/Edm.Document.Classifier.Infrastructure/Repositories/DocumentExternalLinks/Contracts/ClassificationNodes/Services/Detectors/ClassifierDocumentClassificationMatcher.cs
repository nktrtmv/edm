using Edm.Document.Classifier.Domain.Entities.DocumentExternalLinks.ValueObjects.Classifications;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentExternalLinks.Contracts.ClassificationNodes.Services.Detectors;

internal static class ClassifierDocumentClassificationMatcher
{
    internal static bool IsMatched(ClassifierDocumentClassification classification, ClassifierDocumentClassificationNode[] classifications)
    {
        string[] values = GetFlatClassifications(classification);

        bool result = IsMatched(classifications, values);

        return result;
    }

    private static string[] GetFlatClassifications(ClassifierDocumentClassification classification)
    {
        var classifications = new List<string?>
        {
            classification.Category,
            classification.Type,
            classification.Kind
        };

        string[] result = classifications
            .TakeWhile(c => c is not null)
            .OfType<string>()
            .ToArray();

        return result;
    }

    private static bool IsMatched(ClassifierDocumentClassificationNode[] classifications, string[] values)
    {
        if (values.Length == 0 || classifications.Length == 0)
        {
            return true;
        }

        string value = values[0];

        foreach (ClassifierDocumentClassificationNode classification in classifications)
        {
            if (classification.Value != value)
            {
                continue;
            }

            string[] rest = values.Skip(1).ToArray();

            bool result = IsMatched(classification.Subsets, rest);

            if (result)
            {
                return true;
            }
        }

        return false;
    }
}
