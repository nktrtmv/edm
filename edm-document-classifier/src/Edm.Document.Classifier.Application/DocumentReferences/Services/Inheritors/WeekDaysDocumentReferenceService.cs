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
internal sealed class WeekDaysDocumentReferenceService : FixedListDocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.WeekDays,
        DocumentReferenceSearchKind.FixedList,
        DocumentReferenceKind.None,
        "Дни недели");

    protected override DocumentReferenceValue[] Values { get; } =
    [
        new DocumentReferenceValue(
            "Monday",
            "Понедельник",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "Tuesday",
            "Вторник",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "Wednesday",
            "Среда",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "Thursday",
            "Четверг",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "Friday",
            "Пятница",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "Saturday",
            "Суббота",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "Sunday",
            "Воскресенье",
            string.Empty,
            EmptyReference.Instance),
    ];
}
