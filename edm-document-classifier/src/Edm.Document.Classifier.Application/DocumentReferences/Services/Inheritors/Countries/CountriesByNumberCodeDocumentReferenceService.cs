using Edm.Document.Classifier.Application.DocumentReferences.Services.Abstractions.FixedLists;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.Factories;
using Edm.Document.Classifier.Domain.ValueObjects.Countries;

using JetBrains.Annotations;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Countries;

[UsedImplicitly]
internal sealed class CountriesByNumberCodeDocumentReferenceService : FixedListDocumentReferenceService
{
    public override DocumentReferenceType Type => new DocumentReferenceType(
        DocumentReferenceTypeId.CountriesByNumberCode,
        DocumentReferenceSearchKind.FixedList,
        DocumentReferenceKind.None,
        "Страны (3-ех символьный числовой код)");

    protected override DocumentReferenceValue[] Values { get; } = CountryService.GetAll()
        .Where(x => !string.IsNullOrWhiteSpace(x.IsoCode))
        .Select(x => DocumentReferenceValueFactory.CreateFrom(x.IsoCode!, x.NameRu))
        .OrderBy(x => x.DisplayValue)
        .ToArray();
}
