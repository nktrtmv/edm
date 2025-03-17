using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.Values;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.SearchValues.Contracts.Values;

internal static class ApprovalReferenceValueConverter
{
    internal static ApprovalReferenceValueDto FromInternal(DocumentReferenceValueInternal value)
    {
        var result = new ApprovalReferenceValueDto
        {
            Id = value.Id,
            DisplayValue = value.DisplayValue,
            DisplaySubValue = value.DisplaySubValue
        };

        return result;
    }
}
