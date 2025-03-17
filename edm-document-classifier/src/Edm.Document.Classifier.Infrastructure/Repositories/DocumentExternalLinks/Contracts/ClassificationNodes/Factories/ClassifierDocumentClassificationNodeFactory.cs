namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentExternalLinks.Contracts.ClassificationNodes.Factories;

internal static class ClassifierDocumentClassificationNodeFactory
{
    internal static ClassifierDocumentClassificationNode CreateFrom(string classification, params string[] classifications)
    {
        ClassifierDocumentClassificationNode[] subsets = classifications.Select(CreateFrom).ToArray();

        ClassifierDocumentClassificationNode result = CreateFrom(classification, subsets);

        return result;
    }

    private static ClassifierDocumentClassificationNode CreateFrom(string classification)
    {
        ClassifierDocumentClassificationNode[] subsets = Array.Empty<ClassifierDocumentClassificationNode>();

        ClassifierDocumentClassificationNode result = CreateFrom(classification, subsets);

        return result;
    }

    internal static ClassifierDocumentClassificationNode CreateFrom(string classification, params ClassifierDocumentClassificationNode[] subsets)
    {
        var result = new ClassifierDocumentClassificationNode(classification, subsets);

        return result;
    }
}
