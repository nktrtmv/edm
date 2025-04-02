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
internal sealed class ContractSigningTypeDocumentReferenceService : FixedListDocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.ContractSigningTypes,
        DocumentReferenceSearchKind.FixedList,
        DocumentReferenceKind.None,
        "Тип подписания контракта");

    protected override DocumentReferenceValue[] Values { get; } =
    [
        new DocumentReferenceValue(
            "ElectronicDocumentManagement",
            "ЭДО",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "ContractorElectronicDocumentManagement",
            "ЭДО от КА",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "PaperDocumentManagement",
            "БДО",
            string.Empty,
            EmptyReference.Instance)
    ];
}
