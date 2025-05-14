using Edm.Document.Classifier.Application.DocumentReferences;
using Edm.Document.Classifier.Application.DocumentReferences.Services;
using Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors;
using Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Approvals;
using Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Categories;
using Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Categories.MacroBusinessUnit;
using Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Classifications.Inheritors.Categories;
using Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Classifications.Inheritors.Kinds;
using Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Classifications.Inheritors.Types;
using Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Countries;
using Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.SuppliersTypes;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.Factories;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Classifier.Application;

public static class ApplicationRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        AddSingletonReference<EmployeesDocumentReferenceService>(services);
        AddSingletonReference<ContractorPaymentDetailsDocumentReferenceService>(services);
        AddSingletonReference<SelfCompanyPaymentDetailsDocumentReferenceService>(services);
        AddSingletonReference<CurrenciesDocumentReferenceService>(services);
        AddSingletonReference<CalendarTypesDocumentReferenceService>(services);
        AddSingletonReference<SelfCompaniesDocumentReferenceService>(services);
        AddSingletonReference<ContractorsDocumentReferenceService>(services);
        AddSingletonReference<ContractorSegmentDocumentReferenceService>(services);
        AddSingletonReference<ContractSigningTypeDocumentReferenceService>(services);
        AddTransientReference<DocumentCategoriesDocumentReferenceService>(services);
        AddTransientReference<DocumentTypesDocumentReferenceService>(services);
        AddTransientReference<DocumentKindsDocumentReferenceService>(services);
        AddTransientReference<BusinessSegmentsDocumentReferenceService>(services);
        AddSingletonReference<TaxationDocumentReferenceService>(services);
        AddSingletonReference<CategoryFirstLevelDocumentReferenceService>(services);
        AddSingletonReference<CategorySecondLevelDocumentReferenceService>(services);
        AddSingletonReference<MacroBusinessUnitDocumentReferenceService>(services);
        AddSingletonReference<ContractsDocumentReferenceService>(services);
        AddSingletonReference<DocumentsLinksDocumentReferenceService>(services);
        AddSingletonReference<DocumentStagesDocumentReferenceService>(services);
        AddSingletonReference<CountriesByAlphaCodeDocumentReferenceService>(services);
        AddSingletonReference<CountriesByNumberCodeDocumentReferenceService>(services);
        AddSingletonReference<SuppliersTypesDocumentReferenceService>(services);
        AddSingletonReference<WeekDaysDocumentReferenceService>(services);
        AddSingletonReference<StatesDocumentReferenceService>(services);

        AddSingletonReference<PurchaseAgreementsClassificationDocumentReferenceService>(services);

        AddTransientReference<ApprovalBusinessUnitDocumentReferenceService>(services);

        services.AddSingleton<IReferenceServicesProvider, ReferenceServicesProvider>();
        services.AddSingleton<ReferencesWarmUpService>();
    }

    private static void AddSingletonReference<T>(IServiceCollection services) where T : DocumentReferenceService
    {
        services.AddSingleton<DocumentReferenceService, T>();
    }

    private static void AddTransientReference<T>(IServiceCollection services) where T : DocumentReferenceService
    {
        services.AddTransient<DocumentReferenceService, T>();
    }
}
