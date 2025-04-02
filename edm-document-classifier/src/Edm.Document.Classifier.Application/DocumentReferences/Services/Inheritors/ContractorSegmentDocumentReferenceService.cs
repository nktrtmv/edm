using Edm.Document.Classifier.Application.DocumentReferences.Services.Abstractions.FixedLists;
using Edm.Document.Classifier.Domain;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;

using JetBrains.Annotations;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors;

[UsedImplicitly]
internal sealed class ContractorSegmentDocumentReferenceService : FixedListDocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.ContractorSegments,
        DocumentReferenceSearchKind.FixedList,
        DocumentReferenceKind.None,
        "Сегмент контрагента");

    protected override DocumentReferenceValue[] Values { get; } =
    [
        new DocumentReferenceValue(
            "A",
            "A",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "B",
            "B",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "C",
            "C",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "E",
            "E",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "D",
            "СНГ/СТМ",
            string.Empty,
            EmptyReference.Instance)
    ];
}
