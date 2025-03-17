using Edm.Document.Classifier.ExternalServices.DocumentsTemplates.Contracts.Queries.GetDetails;

namespace Edm.Document.Classifier.ExternalServices.DocumentsTemplates.Details;

public interface IDocumentsTemplatesDetails
{
    Task<GetDetailsDocumentsTemplatesQueryExternalResponse> GetDetails(
        GetDetailsDocumentsTemplatesQueryExternal query,
        CancellationToken cancellationToken);
}
