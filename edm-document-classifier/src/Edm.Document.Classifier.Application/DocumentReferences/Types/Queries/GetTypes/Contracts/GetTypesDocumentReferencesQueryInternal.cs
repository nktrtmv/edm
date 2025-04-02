using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts;

public sealed class GetTypesDocumentReferencesQueryInternal : IRequest<GetTypesDocumentReferencesQueryResponseInternal>
{
    private GetTypesDocumentReferencesQueryInternal()
    {
    }

    public static GetTypesDocumentReferencesQueryInternal Instance { get; } = new GetTypesDocumentReferencesQueryInternal();
}
