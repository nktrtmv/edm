using Edm.Document.Searcher.Application.Documents.Services.Updaters;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters.Abstractions;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters.Inheritors.NumbersPrecisions;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters.Inheritors.ReferenceMetazonIds;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Attributes;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Groups.Approvals.Current;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.LegalEntities;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Participants.Approvals.Cumulative;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Participants.Approvals.Current;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Participants.Documents;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.PassApplicantFullNames;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Properties.Audit.ClosedAt;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Properties.Audit.CreatedAt;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Properties.Audit.UpdatedAt;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Properties.Stages;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Properties.Statuses;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Properties.TemplateIds;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts.Factories;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Registrars;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Searcher.Application;

public static class ApplicationServicesRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<SearchDocumentUpdaterContextFactory>();

        services.AddSingleton<ISearchDocumentAttributesValuesCollector, ApprovalCumulativeParticipantsSearchDocumentAttributesValuesCollector>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, ApprovalParticipantsSearchDocumentAttributesValuesCollector>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, ApprovalGroupsSearchDocumentAttributesValuesCollector>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, AttributesSearchDocumentAttributesValuesExtractor>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, DocumentParticipantsSearchDocumentAttributesValuesExtractor>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, CreatedAtSearchDocumentAttributesValuesExtractor>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, UpdatedAtSearchDocumentAttributesValuesExtractor>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, StageSearchDocumentAttributesValuesExtractor>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, StatusSearchDocumentAttributesValuesExtractor>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, LegalEntitiesCollector>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, PassApplicantFullNameSearchDocumentAttributesValuesCollector>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, TemplateIdSearchDocumentAttributesValuesExtractor>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, ClosedAtSearchDocumentAttributesValuesExtractor>();
        services.AddSingleton<ISearchDocumentAttributesValuesCollector, DocumentStateCollector>();

        services.AddSingleton<SearchDocumentAttributesValuesCollector>();

        services.AddSingleton<ISearchDocumentAttributesValuesAdapter, ReferenceMetazonIdSearchDocumentAttributesValuesAdapter>();
        services.AddSingleton<ISearchDocumentAttributesValuesAdapter, NumbersPrecisionsSearchDocumentAttributesValuesAdapter>();

        services.AddSingleton<SearchDocumentAttributeValuesAdapter>();

        services.AddSingleton<SearchDocumentUpdater>();

        DocumentStepperRegistrar.Configure(services);
    }
}
