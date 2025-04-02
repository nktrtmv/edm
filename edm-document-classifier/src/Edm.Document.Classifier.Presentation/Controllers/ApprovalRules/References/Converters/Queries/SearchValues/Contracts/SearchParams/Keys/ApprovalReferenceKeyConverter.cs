using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams.Keys;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams.Keys.ParentValues;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.SearchValues.Contracts.SearchParams.Keys.ParentValues;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.SearchValues.Contracts.SearchParams.Keys;

internal static class ApprovalReferenceKeyConverter
{
    internal static DocumentReferenceKeyInternal ToInternal(ApprovalReferenceKeyDto key)
    {
        Id<DocumentReferenceTypeId> referenceTypeId = ReferenceTypeIdConverter.FromDto(key.ReferenceTypeId);

        DocumentReferenceParentValuesInternal[] parentValues =
            key.ParentValues.Select(ApprovalReferenceParentValuesConverter.ToInternal).ToArray();

        var result = new DocumentReferenceKeyInternal(referenceTypeId, parentValues, key.EntityTypeId);

        return result;
    }
}
