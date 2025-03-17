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
internal sealed class PurchaseAgreementsClassificationDocumentReferenceService : FixedListDocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.PurchaseAgreementsClassification,
        DocumentReferenceSearchKind.FixedList,
        DocumentReferenceKind.None,
        "Классификация договоров покупки");

    protected override DocumentReferenceValue[] Values { get; } =
    [
        new DocumentReferenceValue(
            "ComputerEquipmentPurchase",
            "Закупка компьютерной техники",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "NMAPurchase",
            "Закупка НМА",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "EquipmentPurchase",
            "Закупка оборудования",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "ConstructionInstallationWorksPurchase",
            "Закупка строительно-монтажных работ",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "OfficeGoodsServicesPurchase",
            "Закупка товаров и услуг для офиса",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "OfficeEquipmentMaintenanceServicesProcurement",
            "Закупка услуг на обслуживание офисного оборудования",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "CateringServicesPurchase",
            "Закупка услуг питания",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "RentalServicesPurchase",
            "Закупка услуг по аренде",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "MarketingExhibitionEventServicesPurchase",
            "Закупка услуг по маркетингу (выставки, мероприятия)",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "TrainingServicesPurchase",
            "Закупка услуг по обучению",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "RecruitmentServicesProcurement",
            "Закупка услуг по подбору персонала",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "MediaAdvertisingServicesPurchase",
            "Закупка услуг по размещению медиарекламы",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "AdvertisingServicesPurchase",
            "Закупка услуг по размещению рекламы",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "PremisesMaintenanceServicesPurchase",
            "Закупка услуг по содержанию помещений",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "TechnicalSupportServicesPurchase",
            "Закупка услуг по технической поддержке",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "MarketingResearch",
            "Маркетинговое исследование",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "TelecommunicationServicesProvision",
            "Оказание телекоммуникационных услуг",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "AuditServicesProvision",
            "Оказание услуг аудита",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "ConsultingServicesProvision",
            "Оказание услуг консалтинга",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "PartnershipAgreement",
            "Партнерский договор",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "IntellectualPropertyUsageTransfer",
            "Передача в пользование НМА, объектов инт. собственности",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "OtherOperatingSystemsAcquisition",
            "Приобретение прочих ОС (Инвестиционная деятельность)",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "MiscellaneousServicesMaterialsPurchase",
            "Приобретение прочих услуг, материалов",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "CorporateEvents",
            "Проведение корпоративных мероприятий",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "RKO",
            "РКО",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "Insurance",
            "Страхование",
            string.Empty,
            EmptyReference.Instance),
        new DocumentReferenceValue(
            "NonDisclosureAgreement",
            "Соглашение о неразглашении",
            string.Empty,
            EmptyReference.Instance),
    ];
}
