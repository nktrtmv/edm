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
internal sealed class DocumentStagesDocumentReferenceService : FixedListDocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.DocumentStages,
        DocumentReferenceSearchKind.FixedList,
        DocumentReferenceKind.None,
        "Статус");

    protected override DocumentReferenceValue[] Values { get; } =
    [
        new DocumentReferenceValue(
            "1",
            "Черновик",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "2",
            "Ожидает обработки",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "3",
            "Подготовка к согласованию",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "4",
            "На согласовании",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "5",
            "Подготовка к подписанию",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "6",
            "На подписании",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "7",
            "Действует",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "8",
            "Отменен",
            string.Empty,
            EmptyReference.Instance)
    ];
}
