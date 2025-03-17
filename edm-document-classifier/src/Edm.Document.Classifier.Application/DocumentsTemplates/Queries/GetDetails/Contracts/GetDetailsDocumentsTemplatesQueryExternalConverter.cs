using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.ExternalServices.DocumentsTemplates.Contracts.Queries.GetDetails;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Application.DocumentsTemplates.Queries.GetDetails.Contracts;

internal static class GetDetailsDocumentsTemplatesQueryExternalConverter
{
    internal static GetDetailsDocumentsTemplatesQueryExternal FromDomain(Id<DocumentTemplate>[] documentTemplateIds)
    {
        var result = new GetDetailsDocumentsTemplatesQueryExternal(documentTemplateIds);
        return result;
    }
}
