using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts;
using Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.GetTypes.Contracts.Types;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.GetTypes;

internal static class GetTypesApprovalReferencesQueryResponseConverter
{
    internal static GetTypesApprovalReferencesQueryResponse FromInternal(GetTypesDocumentReferencesQueryResponseInternal response)
    {
        ApprovalReferenceTypeDto[] types =
            response.Types.Select(ApprovalReferenceTypeConverter.ToDto).ToArray();

        var result = new GetTypesApprovalReferencesQueryResponse
        {
            Types_ = { types }
        };

        return result;
    }
}
