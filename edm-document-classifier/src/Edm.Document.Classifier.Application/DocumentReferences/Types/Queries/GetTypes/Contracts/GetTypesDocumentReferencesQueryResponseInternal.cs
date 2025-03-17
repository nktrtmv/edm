using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts;

public sealed class GetTypesDocumentReferencesQueryResponseInternal
{
    internal GetTypesDocumentReferencesQueryResponseInternal(DocumentReferenceTypeInternal[] types)
    {
        Types = types;
    }

    public DocumentReferenceTypeInternal[] Types { get; }
}
