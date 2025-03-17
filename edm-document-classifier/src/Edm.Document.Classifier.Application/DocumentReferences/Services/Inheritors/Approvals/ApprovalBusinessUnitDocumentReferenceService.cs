using Edm.Document.Classifier.Application.DocumentReferences.Services.Abstractions.FixedLists;
using Edm.Document.Classifier.Domain;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;

using JetBrains.Annotations;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Approvals;

[UsedImplicitly]
internal class ApprovalBusinessUnitDocumentReferenceService : FixedListDocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.ApprovalBusinessUnit,
        DocumentReferenceSearchKind.FixedList,
        DocumentReferenceKind.None,
        "Заявка на обучение. Бизнес юнит");

    protected override DocumentReferenceValue[] Values { get; } =
    [
        new DocumentReferenceValue(
            "SelfTech",
            "Self Tech",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "BigSelf",
            "Большой Self (не Tech)",
            string.Empty,
            EmptyReference.Instance)
    ];
}
