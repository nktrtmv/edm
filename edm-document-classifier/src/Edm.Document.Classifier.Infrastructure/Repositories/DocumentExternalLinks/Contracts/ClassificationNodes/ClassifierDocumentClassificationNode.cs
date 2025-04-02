namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentExternalLinks.Contracts.ClassificationNodes;

internal sealed class ClassifierDocumentClassificationNode
{
    internal ClassifierDocumentClassificationNode(string value, ClassifierDocumentClassificationNode[] subsets)
    {
        Value = value;
        Subsets = subsets;
    }

    internal string Value { get; }
    internal ClassifierDocumentClassificationNode[] Subsets { get; }
}
