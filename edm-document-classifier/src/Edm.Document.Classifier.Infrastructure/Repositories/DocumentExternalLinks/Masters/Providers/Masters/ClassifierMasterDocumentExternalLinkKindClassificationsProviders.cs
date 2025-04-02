using Edm.Document.Classifier.Infrastructure.Repositories.DocumentExternalLinks.Contracts.ClassificationNodes;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentExternalLinks.Contracts.ClassificationNodes.Factories;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentExternalLinks.Masters.Providers.Masters;

internal static class ClassifierMasterDocumentExternalLinkKindClassificationsProviders
{
    internal static readonly ClassifierDocumentClassificationNode[] Rent =
    {
        ClassifierDocumentClassificationNodeFactory.CreateFrom(
            "2",
            ClassifierDocumentClassificationNodeFactory.CreateFrom("2_14", "2_14_1", "2_14_2", "2_14_3", "2_14_4", "2_14_5", "2_14_6", "2_14_7"),
            ClassifierDocumentClassificationNodeFactory.CreateFrom("2_15", "2_15_1", "2_15_2", "2_15_3"),
            ClassifierDocumentClassificationNodeFactory.CreateFrom("2_16", "2_16_1", "2_16_2", "2_16_3", "2_16_4", "2_16_5", "2_16_6", "2_16_7"),
            ClassifierDocumentClassificationNodeFactory.CreateFrom("2_17", "2_17_1", "2_17_2", "2_17_3", "2_17_4", "2_17_5", "2_17_6", "2_17_7", "2_17_8"),
            ClassifierDocumentClassificationNodeFactory.CreateFrom("2_18", "2_18_1", "2_18_2"),
            ClassifierDocumentClassificationNodeFactory.CreateFrom("2_19", "2_19_1"),
            ClassifierDocumentClassificationNodeFactory.CreateFrom("2_20", "2_20_1", "2_20_2", "2_20_3"))
    };

    internal static readonly ClassifierDocumentClassificationNode[] Ppsm =
    {
        ClassifierDocumentClassificationNodeFactory.CreateFrom(
            "1",
            ClassifierDocumentClassificationNodeFactory.CreateFrom("11", "1_11_48"))
    };

    internal static readonly ClassifierDocumentClassificationNode[] RealizationContracts =
    {
        ClassifierDocumentClassificationNodeFactory.CreateFrom(
            "1",
            ClassifierDocumentClassificationNodeFactory.CreateFrom("1", "2"))
    };

    internal static readonly ClassifierDocumentClassificationNode[] PurchaseContracts =
    {
        ClassifierDocumentClassificationNodeFactory.CreateFrom(
            "1",
            ClassifierDocumentClassificationNodeFactory.CreateFrom("1", "1", "24", "25", "1_1_26"))
    };

    internal static readonly ClassifierDocumentClassificationNode[] MarketingSalesContracts =
    {
        ClassifierDocumentClassificationNodeFactory.CreateFrom(
            "1",
            ClassifierDocumentClassificationNodeFactory.CreateFrom("12", "17"))
    };

    internal static readonly ClassifierDocumentClassificationNode[] DcOtherContracts =
    {
        ClassifierDocumentClassificationNodeFactory.CreateFrom(
            "2",
            ClassifierDocumentClassificationNodeFactory.CreateFrom("2_21", "2_21_1", "2_21_2", "2_21_3", "2_21_4", "2_21_5"))
    };

    internal static readonly ClassifierDocumentClassificationNode[] DcOtherAdditionalAgreements =
    {
        ClassifierDocumentClassificationNodeFactory.CreateFrom(
            "2",
            ClassifierDocumentClassificationNodeFactory.CreateFrom("2_22", "2_22_1", "2_22_2"))
    };
}
