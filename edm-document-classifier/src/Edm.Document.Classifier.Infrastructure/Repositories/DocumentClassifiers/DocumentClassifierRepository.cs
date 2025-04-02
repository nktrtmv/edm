using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments.Factories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds.Factories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.Factories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.Factories;
using Edm.Document.Classifier.Domain.ValueObjects.Usages;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentClassifiers;

internal sealed class DocumentClassifierRepository : IDocumentClassifierRepository
{
    private readonly BusinessSegment[] _businessSegments =
    {
        BusinessSegmentFactory.CreateFrom("1", "Retail", "RT - Ритейл"),
        BusinessSegmentFactory.CreateFrom("2", "Express", "EX - Фреш"),
        BusinessSegmentFactory.CreateFrom("3", "Marketplace", "MP - Маркетплейс"),
        BusinessSegmentFactory.CreateFrom("4", "Fulfillment", "FF - Фулфилмент"),
        BusinessSegmentFactory.CreateFrom("5", "Global", "GB - Глобал"),
        BusinessSegmentFactory.CreateFrom("6", "Holding", "OH - Озон Холдинг"),
        BusinessSegmentFactory.CreateFrom("7", "Fintech", "FT - Финтех"),
        BusinessSegmentFactory.CreateFrom("8", "Trevel", "TV - Тревел", Usage.Unused),
        BusinessSegmentFactory.CreateFrom("9", "Logistics", "LG - Логистика", Usage.Unused),
        BusinessSegmentFactory.CreateFrom("10", "Cis", "CIS - СНГ", Usage.Unused),
        BusinessSegmentFactory.CreateFrom("11", "Commercial", "KD - Коммерческая дирекция"),
        BusinessSegmentFactory.CreateFrom("12", "Metropolitan", "MTP - Метрополитан"),
        BusinessSegmentFactory.CreateFrom("13", "Travel", "TR - Тревел")
    };

    private readonly DocumentCategory[] _documentCategories =
    {
        DocumentCategoryFactory.CreateFrom(
            "1",
            "commercial",
            "Коммерческий (TP)",
            new[]
            {
                DocumentTypeFactory.CreateFrom(
                    "1",
                    "Договор поставки",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("1", "Закупка"),
                        DocumentKindFactory.CreateFrom("2", "Реализация"),
                        DocumentKindFactory.CreateFrom("1_1_17", "Договор обратной поставки", Usage.Unused),
                        DocumentKindFactory.CreateFrom("18", "Договор поставки - доходный"),
                        DocumentKindFactory.CreateFrom("24", "Договор поставки - разовая закупка"),
                        DocumentKindFactory.CreateFrom("25", "Договор поставки - сырье"),
                        DocumentKindFactory.CreateFrom("1_1_26", "Договор выкуп упаковки"),
                        DocumentKindFactory.CreateFrom("1_1_27", "Договор уполномоченного представителя")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2",
                    "Агентский договор",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("4", "Агентский договор - стандартный", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "1_3",
                    "Договор продажи",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("1_3_1", "Договор продажи В2В")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "1_4",
                    "Договор дубль",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("1_4_1", "Договор дубль")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "5",
                    "Договор комиссии",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("9", "Договор комиссии - селлеры", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "6",
                    "Договор оказания услуг/выполнения работ",
                    Usage.Unused,
                    Array.Empty<DocumentKind>()),
                DocumentTypeFactory.CreateFrom(
                    "7",
                    "Дополнительное соглашение",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("19", "Дополнительное соглашение на изменение / дополнение условий договора"),
                        DocumentKindFactory.CreateFrom("26", "Дополнительное соглашение на EDI, ЭДО"),
                        DocumentKindFactory.CreateFrom("27", "Дополнительное соглашение на выдачу банковской гарантии"),
                        DocumentKindFactory.CreateFrom("28", "Дополнительное соглашение на изменение порядка оплаты"),
                        DocumentKindFactory.CreateFrom("29", "Дополнительное соглашение на пролонгацию договора"),
                        DocumentKindFactory.CreateFrom("30", "Дополнительное соглашение о премии за товарооборот"),
                        DocumentKindFactory.CreateFrom("31", "Дополнительное соглашение о логистическом бонусе"),
                        DocumentKindFactory.CreateFrom("32", "Дополнительное соглашение на оказание услуг в кабинете Performance"),
                        DocumentKindFactory.CreateFrom("33", "Дополнительное соглашение на оказание информационных услуг"),
                        DocumentKindFactory.CreateFrom("34", "Дополнительное соглашение о кросс-докинге"),
                        DocumentKindFactory.CreateFrom("35", "Дополнительное соглашение о доверительной приемке"),
                        DocumentKindFactory.CreateFrom("36", "Дополнительное соглашение о невозврате многооборотной тары"),
                        DocumentKindFactory.CreateFrom("37", "Дополнительное соглашения об адресах поставки"),
                        DocumentKindFactory.CreateFrom("38", "Дополнительное соглашения о штрафах", Usage.Unused),
                        DocumentKindFactory.CreateFrom("39", "Дополнительное соглашение - СТМ"),
                        DocumentKindFactory.CreateFrom("40", "Дополнительное соглашение на включение спецификации - сырье"),
                        DocumentKindFactory.CreateFrom("41", "Дополнительное соглашение на обратную поставку"),
                        DocumentKindFactory.CreateFrom("42", "Дополнительное соглашение об изложении Спецификации в новой редакции"),
                        DocumentKindFactory.CreateFrom("43", "Дополнительное соглашение об изложении Промо-спецификации в новой редакции"),
                        DocumentKindFactory.CreateFrom("44", "Дополнительное соглашение об изложении Заказа в новой редакции"),
                        DocumentKindFactory.CreateFrom("1_7_47", "Дополнительное соглашение - антикоррупционная оговорка", Usage.Unused),
                        DocumentKindFactory.CreateFrom("48", "Дополнительное соглашение к договорам маркетинга"),
                        DocumentKindFactory.CreateFrom("49", "Дополнительное соглашение на отказ от рекламаций"),
                        DocumentKindFactory.CreateFrom("50", "Дополнительное соглашение о сервисном бонусе"),
                        DocumentKindFactory.CreateFrom("51", "Дополнительное соглашение о новой приемке"),
                        DocumentKindFactory.CreateFrom("52", "Дополнительное соглашение о маркировке"),
                        DocumentKindFactory.CreateFrom("53", "Дополнительное соглашение недостача и брак"),
                        DocumentKindFactory.CreateFrom("54", "Дополнительное соглашение о добавлении бренда"),
                        DocumentKindFactory.CreateFrom("55", "Дополнительное соглашение об изложении текста договора по условиям Озон"),
                        DocumentKindFactory.CreateFrom("56", "Дополнительное соглашение скидки и промо"),
                        DocumentKindFactory.CreateFrom("57", "Дополнительное соглашение о доп.упаковке / стикировке"),
                        DocumentKindFactory.CreateFrom("58", "Дополнительное соглашение на услуги склада"),
                        DocumentKindFactory.CreateFrom("1_7_60", "Дополнительное соглашение на изменение условий отгрузки"),
                        DocumentKindFactory.CreateFrom("1_7_61", "Дополнительное соглашение на работу в Личном кабинете"),
                        DocumentKindFactory.CreateFrom("1_7_62", "Дополнительное соглашение платежный агент"),
                        DocumentKindFactory.CreateFrom("1_7_63", "Дополнительное соглашение на выкуп упаковки"),
                        DocumentKindFactory.CreateFrom("1_7_64", "Дополнительное соглашение на изменение банковских реквизитов поставщика"),
                        DocumentKindFactory.CreateFrom("1_7_65", "Дополнительное соглашение на оплату третьему лицу"),
                        DocumentKindFactory.CreateFrom("1_7_66", "Дополнительное соглашение на увеличение срока согласования заказа"),
                        DocumentKindFactory.CreateFrom("1_7_67", "Дополнительное соглашение Прочие"),
                        DocumentKindFactory.CreateFrom("1_7_68", "Дополнительное соглашение Индивидуальные условия"),
                        DocumentKindFactory.CreateFrom("1_7_69", "Дополнительное соглашение на ИУ: коэффициент выкупной цены"),
                        DocumentKindFactory.CreateFrom("1_7_70", "Дополнительное соглашение абонентский маркетинг"),
                        DocumentKindFactory.CreateFrom("1_7_71", "Дополнительное соглашение комиссия + абонентский маркетинг"),
                        DocumentKindFactory.CreateFrom("1_7_72", "Дополнительное соглашение НКО"),
                        DocumentKindFactory.CreateFrom("1_7_73", "Дополнительное соглашение порядок приемки/ вывоза"),
                        DocumentKindFactory.CreateFrom("1_7_74", "Дополнительное соглашение условия оплаты/стоимость/оплата"),
                        DocumentKindFactory.CreateFrom("1_7_75", "Дополнительное соглашение Flex"),
                        DocumentKindFactory.CreateFrom("1_7_76", "Дополнительное соглашение агрегатор"),
                        DocumentKindFactory.CreateFrom("1_7_77", "Дополнительное соглашение Эконом"),
                        DocumentKindFactory.CreateFrom("1_7_78", "Дополнительное соглашение на пролонгацию"),
                        DocumentKindFactory.CreateFrom("1_7_79", "Дополнительное соглашение изменение/дополнение пункта договора"),
                        DocumentKindFactory.CreateFrom("1_7_80", "Дополнительное соглашение к договорам маркетинга"),
                        DocumentKindFactory.CreateFrom("1_7_81", "Дополнительное соглашение о применении НДС"),
                        DocumentKindFactory.CreateFrom("1_7_82", "Дополнительное соглашение об утилизации"),
                    }),
                DocumentTypeFactory.CreateFrom(
                    "8",
                    "Коммерческие условия",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("1_8_20", "Коммерческие условия к договору коммерческой поставки", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "9",
                    "Соглашение о перемене лиц в обязательстве",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("20", "Соглашение о перемене лиц в обязательстве")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "10",
                    "Соглашение о расторжении",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("21", "Соглашение о расторжении")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "11",
                    "Спецификация",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("22", "Промо-спецификация"),
                        DocumentKindFactory.CreateFrom("23", "Спецификация - стандартная"),
                        DocumentKindFactory.CreateFrom("46", "Спецификация - сырье"),
                        DocumentKindFactory.CreateFrom("47", "Спецификация СТМ с предварительно согласованным техническим обоснованием"),
                        DocumentKindFactory.CreateFrom("1_11_48", "Коммерческий расчёт"),
                        DocumentKindFactory.CreateFrom("1_11_49", "Спецификация B2B")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "12",
                    "Договор маркетинговых услуг",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("16", "Договор на оказание услуг в кабинете Performance", Usage.Unused),
                        DocumentKindFactory.CreateFrom("17", "Договор маркетинг")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "13",
                    "Соглашение о конфиденциальности",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("45", "Соглашение о конфиденциальности")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "1_14",
                    "Договор агентский",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("1_14_1", "Договор агентский")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "1_15",
                    "Договор",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("1_15_1", "Договор комиссии (Дубль)"),
                        DocumentKindFactory.CreateFrom("1_15_2", "Договор рекламно-информационных услуг"),
                        DocumentKindFactory.CreateFrom("1_15_3", "Договор о соглашении о неразглашении (NDA)"),
                        DocumentKindFactory.CreateFrom("1_15_4", "Оплата по договорам цессии"),
                        DocumentKindFactory.CreateFrom("1_15_5", "Агентский договор без сбора ден. средств (Аутсорс Флекс)"),
                        DocumentKindFactory.CreateFrom("1_15_6", "Агентский договор со сбором ден. средств (Аутсорс Флекс)"),
                    }),
                DocumentTypeFactory.CreateFrom(
                    "1_16",
                    "Соглашение",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("1_16_1", "PLA Индивидуальные условия"),
                        DocumentKindFactory.CreateFrom("1_16_2", "PLA Оферта"),
                    })
            }),
        DocumentCategoryFactory.CreateFrom(
            "2",
            "non_commercial",
            "Некоммерческий (NTP)",
            new[]
            {
                DocumentTypeFactory.CreateFrom(
                    "2_2",
                    "Агентский договор",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_2_4", "Агентский договор - стандартный", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_3",
                    "Договор аренды движимого имущества",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_3_5", "Договор аренды движимого имущества", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_4",
                    "Договор аренды недвижимости",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_4_6", "Договор аренды недвижимости - офис", Usage.Unused),
                        DocumentKindFactory.CreateFrom("2_4_7", "Договор аренды недвижимости - ПВЗ", Usage.Unused),
                        DocumentKindFactory.CreateFrom("2_4_8", "Договор аренды недвижимости - фулфилмент", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_6",
                    "Договор оказания услуг/выполнения работ",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_6_10", "Договор на оказание коммунальных услуг", Usage.Unused),
                        DocumentKindFactory.CreateFrom("2_6_12", "Договор на оказание услуг клининга", Usage.Unused),
                        DocumentKindFactory.CreateFrom("2_6_13", "Договор на оказание услуг по парковке", Usage.Unused),
                        DocumentKindFactory.CreateFrom("2_6_14", "Договор оказания охранных услуг", Usage.Unused),
                        DocumentKindFactory.CreateFrom("2_6_15", "Договор оказания услуг/выполнения работ - стандартный", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_7",
                    "Дополнительное соглашение",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_7_19", "Дополнительное соглашение на изменение / дополнение условий договора", Usage.Unused),
                        DocumentKindFactory.CreateFrom("2_7_47", "Дополнительное соглашение - антикоррупционная оговорка", Usage.Unused),
                        DocumentKindFactory.CreateFrom("2_7_27", "Дополнительное соглашение на выдачу банковской гарантии", Usage.Unused),
                        DocumentKindFactory.CreateFrom("2_7_28", "Дополнительное соглашение на изменение порядка оплаты", Usage.Unused),
                        DocumentKindFactory.CreateFrom("2_7_29", "Дополнительное соглашение на пролонгацию договора", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_9",
                    "Соглашение о перемене лиц в обязательстве",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_9_20", "Соглашение о перемене лиц в обязательстве", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_10",
                    "Соглашение о расторжении",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_10_21", "Соглашение о расторжении", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_11",
                    "Спецификация",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_11_22", "Промо-спецификация", Usage.Unused),
                        DocumentKindFactory.CreateFrom("2_11_23", "Спецификация - стандартная", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_13",
                    "Соглашение о конфиденциальности",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_13_45", "Соглашение о конфиденциальности", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_14",
                    "Договор аренды",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_14_1", "Договор аренды/субаренды автотранспорта"),
                        DocumentKindFactory.CreateFrom("2_14_2", "Договор аренды/субаренды земельных участков/парковочных мест"),
                        DocumentKindFactory.CreateFrom("2_14_3", "Договор аренды/субаренды помещений без поэтапного признания"),
                        DocumentKindFactory.CreateFrom("2_14_4", "Договор аренды/субаренды оборудования"),
                        DocumentKindFactory.CreateFrom("2_14_5", "Договор оказания коворкинг-услуг"),
                        DocumentKindFactory.CreateFrom("2_14_6", "Долгосрочный договор аренды/субаренды с поэтапным признанием"),
                        DocumentKindFactory.CreateFrom("2_14_7", "Предварительный договор аренды/субаренды с поэтапным признанием"),
                        DocumentKindFactory.CreateFrom("2_14_8", "Документ о перезаключении", Usage.Reserved) // Used in Rent
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_15",
                    "Дополнительное соглашение (аренда)",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_15_1", "ДС об изменении/дополнении условий договора"),
                        DocumentKindFactory.CreateFrom("2_15_2", "ДС о замене сторон"),
                        DocumentKindFactory.CreateFrom("2_15_3", "ДС о расторжении договора"),
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_16",
                    "Акт (аренда)",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_16_1", "Акт выбытия"),
                        DocumentKindFactory.CreateFrom("2_16_2", "Акт доступа"),
                        DocumentKindFactory.CreateFrom("2_16_3", "Акт приема-передачи"),
                        DocumentKindFactory.CreateFrom("2_16_4", "Акт об обеспечении строительной готовности"),
                        DocumentKindFactory.CreateFrom("2_16_5", "Акт передачи в фактическое пользование"),
                        DocumentKindFactory.CreateFrom("2_16_6", "Разрешение на ввод в эксплуатацию"),
                        DocumentKindFactory.CreateFrom("2_16_7", "Дополнение к акту приема-передачи")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_17",
                    "Уведомление (аренда)",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_17_1", "Уведомление о замерах"),
                        DocumentKindFactory.CreateFrom("2_17_2", "Уведомление об изменении курса валют"),
                        DocumentKindFactory.CreateFrom("2_17_3", "Уведомление о переплате/недоплате"),
                        DocumentKindFactory.CreateFrom("2_17_4", "Уведомление о смене стороны"),
                        DocumentKindFactory.CreateFrom("2_17_5", "Уведомление о смене управляющей компании"),
                        DocumentKindFactory.CreateFrom("2_17_6", "Уведомление об индексации"),
                        DocumentKindFactory.CreateFrom("2_17_7", "Информационное письмо от страховой компании"),
                        DocumentKindFactory.CreateFrom("2_17_8", "Уведомление о расторжении")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_18",
                    "Служебная записка (аренда)",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_18_1", "Служебная записка от отдела развития бизнеса"),
                        DocumentKindFactory.CreateFrom("2_18_2", "Служебная записка (исправление)")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_19",
                    "Приложение (аренда)",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_19_1", "Приложение к договору")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_20",
                    "Соглашение (аренда)",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_20_1", "Соглашения о намерениях на заключение ДА"),
                        DocumentKindFactory.CreateFrom("2_20_2", "Соглашение о предоставлении опциона"),
                        DocumentKindFactory.CreateFrom("2_20_3", "Соглашение о расторжении")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_21",
                    "Договор",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_21_1", "Соглашение о неразглашении"),
                        DocumentKindFactory.CreateFrom("2_21_2", "Договор-оферта"),
                        DocumentKindFactory.CreateFrom("2_21_3", "Разовый договор"),
                        DocumentKindFactory.CreateFrom("2_21_4", "Рамочный договор"),
                        DocumentKindFactory.CreateFrom("2_21_5", "Счет")
                    }),
                DocumentTypeFactory.CreateFrom(
                    "2_22",
                    "ДС",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("2_22_1", "Доп соглашения"),
                        DocumentKindFactory.CreateFrom("2_22_2", "Спецификация")
                    })
            }),
        DocumentCategoryFactory.CreateFrom(
            "3",
            "intragroup",
            "Внутригрупповой (VGO)",
            new[]
            {
                DocumentTypeFactory.CreateFrom(
                    "3_2",
                    "Агентский договор",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("3_2_4", "Агентский договор - стандартный", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "3_6",
                    "Договор оказания услуг/выполнения работ",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("3_6_15", "Договор оказания услуг/выполнения работ - стандартный", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "3_7",
                    "Дополнительное соглашение",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("3_7_19", "Дополнительное соглашение на изменение / дополнение условий договора", Usage.Unused),
                        DocumentKindFactory.CreateFrom("3_7_27", "Дополнительное соглашение на выдачу банковской гарантии", Usage.Unused),
                        DocumentKindFactory.CreateFrom("3_7_28", "Дополнительное соглашение на изменение порядка оплаты", Usage.Unused),
                        DocumentKindFactory.CreateFrom("3_7_29", "Дополнительное соглашение на пролонгацию договора", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "3_9",
                    "Соглашение о перемене лиц в обязательстве",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("3_9_20", "Соглашение о перемене лиц в обязательстве", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "3_10",
                    "Соглашение о расторжении",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("3_10_21", "Соглашение о расторжении", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "3_11",
                    "Спецификация",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("3_11_22", "Промо-спецификация", Usage.Unused),
                        DocumentKindFactory.CreateFrom("3_11_23", "Спецификация - стандартная", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "3_12",
                    "Договор",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("3_12_1", "Договор займа"),
                        DocumentKindFactory.CreateFrom("3_12_2", "Договор закупки транспортных услуг"),
                        DocumentKindFactory.CreateFrom("3_12_3", "Договор закупки услуг по аренде"),
                        DocumentKindFactory.CreateFrom("3_12_4", "Договор закупки услуг по подбору персонала"),
                        DocumentKindFactory.CreateFrom("3_12_5", "Договор на оказание услуг консалтинга"),
                        DocumentKindFactory.CreateFrom("3_12_6", "Договор на приобретение прочих ОС (Инвестиционная деятельность)"),
                        DocumentKindFactory.CreateFrom("3_12_7", "Договор на приобретение прочих услуг, материалов"),
                        DocumentKindFactory.CreateFrom("3_12_8", "Договор о соглашении о неразглашении"),
                        DocumentKindFactory.CreateFrom("3_12_9", "Договор оказания услуг колл-центра"),
                        DocumentKindFactory.CreateFrom("3_12_10", "Договор реализации тур.услуг"),
                        DocumentKindFactory.CreateFrom("3_12_11", "Договор факторинга"),
                        DocumentKindFactory.CreateFrom("3_12_12", "Договор закупки НМА"),
                        DocumentKindFactory.CreateFrom("3_12_13", "Цессии"),
                        DocumentKindFactory.CreateFrom("3_12_14", "Агентские договоры"),
                        DocumentKindFactory.CreateFrom("3_12_15", "Договор на закупку услуг по размещению рекламы"),
                    }),
                DocumentTypeFactory.CreateFrom(
                    "3_13",
                    "Дополнительное соглашение",
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("3_13_1", "Дополнительное соглашение"),
                        DocumentKindFactory.CreateFrom("3_13_2", "Спецификация"),
                    })
            }),
        DocumentCategoryFactory.CreateFrom(
            "4",
            "investment",
            "Инвестиционный (MA)",
            Usage.Unused,
            new[]
            {
                DocumentTypeFactory.CreateFrom(
                    "4_7",
                    "Дополнительное соглашение",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("4_7_19", "Дополнительное соглашение на изменение / дополнение условий договора", Usage.Unused),
                        DocumentKindFactory.CreateFrom("4_7_27", "Дополнительное соглашение на выдачу банковской гарантии", Usage.Unused),
                        DocumentKindFactory.CreateFrom("4_7_28", "Дополнительное соглашение на изменение порядка оплаты", Usage.Unused),
                        DocumentKindFactory.CreateFrom("4_7_29", "Дополнительное соглашение на пролонгацию договора", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "4_9",
                    "Соглашение о перемене лиц в обязательстве",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("4_9_20", "Соглашение о перемене лиц в обязательстве", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "4_10",
                    "Соглашение о расторжении",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("4_10_21", "Соглашение о расторжении", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "4_11",
                    "Спецификация",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("4_11_22", "Промо-спецификация", Usage.Unused),
                        DocumentKindFactory.CreateFrom("4_11_23", "Спецификация - стандартная", Usage.Unused)
                    }),
                DocumentTypeFactory.CreateFrom(
                    "4_13",
                    "Соглашение о конфиденциальности",
                    Usage.Unused,
                    new[]
                    {
                        DocumentKindFactory.CreateFrom("4_13_45", "Соглашение о конфиденциальности", Usage.Unused)
                    })
            })
    };

    public Task<DocumentClassifier> Get(CancellationToken cancellationToken)
    {
        var result = new DocumentClassifier(_businessSegments, _documentCategories);

        return Task.FromResult(result);
    }
}
