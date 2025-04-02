using Edm.Document.Classifier.Application.DocumentReferences.Services.Abstractions.FixedLists;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.Factories;

using JetBrains.Annotations;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.SuppliersTypes;

[UsedImplicitly]
internal sealed class SuppliersTypesDocumentReferenceService : FixedListDocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.SupplierTypes,
        DocumentReferenceSearchKind.FixedList,
        DocumentReferenceKind.None,
        "Тип поставщика");

    protected override DocumentReferenceValue[] Values { get; } =
    [
        DocumentReferenceValueFactory.CreateFrom("Resident", "Резидент"),
        DocumentReferenceValueFactory.CreateFrom("NonResident", "Не резидент"),
    ];
}
