using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.ExternalServices.DocumentsTemplates.Contracts.Queries.GetDetails;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Application.DocumentsTemplates.Queries.GetDetails.Contracts;

internal static class GetDetailsDocumentsTemplatesQueryExternalResponseConverter
{
    internal static Id<DocumentTemplate>[] ToDomain(GetDetailsDocumentsTemplatesQueryExternalResponse response)
    {
        Id<DocumentTemplate>[] result = response.DocumentTemplateIds;
        
        return result;
    }
}
