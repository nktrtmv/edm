using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Enrichers.References;

public static class ReferenceValueEnricherKeyConverter
{
    public static GetReferenceValuesSearchQuery ToQuery(string templateId, string referenceTypeId, string[] ids)
    {
        var result = new GetReferenceValuesSearchQuery
        {
            Limit = int.MaxValue,
            Query = string.Empty,
            ReferenceType = referenceTypeId,
            Skip = 0,
            Ids = { ids },
            TemplateId = templateId
        };

        return result;
    }
}
