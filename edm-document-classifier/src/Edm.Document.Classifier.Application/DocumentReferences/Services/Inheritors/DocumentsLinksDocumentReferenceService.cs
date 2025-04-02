using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;
using Edm.Document.Classifier.ExternalServices.Documents.Contracts;
using Edm.Document.Classifier.ExternalServices.Documents.Details;
using Edm.Document.Classifier.ExternalServices.DocumentsSearchers;

using JetBrains.Annotations;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors;

[UsedImplicitly]
internal sealed class DocumentsLinksDocumentReferenceService(IDocumentsSearchersClient documentsSearchers, IDocumentsDetailsClient documentsDetails)
    : DocumentReferenceService
{
    private const int SearchQueryTake = 6;
    private const int SearchQuerySkip = 0;

    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.DocumentsLinks,
        DocumentReferenceSearchKind.Search,
        DocumentReferenceKind.None,
        "Ссылки на договоры");

    public override async Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        string[] documentsIds;

        if (searchParams.Ids.Length != 0)
        {
            documentsIds = searchParams.Ids.ToArray();
        }
        else
        {
            documentsIds = await documentsSearchers.SearchByRegistrationNumber(searchParams.Search, SearchQueryTake, SearchQuerySkip, cancellationToken);
        }

        DocumentDetailsEx[] documents = await documentsDetails.GetDetails(documentsIds, cancellationToken);

        DocumentReferenceValue[] result = documents.Select(
                d => new DocumentReferenceValue(
                    d.Id,
                    d.RegistrationNumber,
                    d.StageType,
                    d))
            .ToArray();

        return result;
    }
}
