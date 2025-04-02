using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsClerks;
using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses;
using Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Create;
using Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Update;
using Edm.DocumentGenerator.Gateway.Core.Counters.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.Counters.Queries.GetCounters;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetBusinessSegments;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentCategories;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentKinds;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentTypes;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByClassification;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByTemplate;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Delete;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.ProcessAll;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors.Inheritors.Default;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors.Inheritors.Signatory;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Fetchers.Approval;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Fetchers.Signing;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Fetchers.Approval;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Fetchers.Signing;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.GetDocumentsAttributes;
using Edm.DocumentGenerator.Gateway.Core.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType;
using Edm.DocumentGenerator.Gateway.Core.DocumentsSystemAttributes.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.AddParticipant;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Complete;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Delegate;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.TakeInWork;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetAddParticipantDetails;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetDelegateDetails;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Cancel;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.PutIntoEffect;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.ReturnToRework;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.SendToContractor;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Sign;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.WithdrawByContractor;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.WithdrawBySelf;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Queries.GetDocumentsToSign;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetArchiveDetails;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Create;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Delete;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.MigrateAll;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Update;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAllDocumentsStatuses;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Create;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Update;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetNewReferenceTypeId;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetReferencesTypes;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Create;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Update;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Upload;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetReferencesTypeValuesSearch;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Count;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.QuickFilters;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Sources;

namespace Edm.DocumentGenerator.Gateway.Core;

public static class CoreRegistrar
{
    public static void Configure(IConfiguration configuration, IServiceCollection services)
    {
        services.AddSingleton<DeleteDocumentsService>();
        services.AddSingleton<DocumentGeneratorService>();

        services.AddSingleton<CreateDocumentTemplateService>();
        services.AddSingleton<DeleteDocumentTemplateService>();
        services.AddSingleton<GetAllDocumentTemplatesService>();
        services.AddSingleton<GetAllDocumentsStatusesDocumentTemplatesService>();
        services.AddSingleton<GetDocumentTemplateService>();
        services.AddSingleton<UpdateDocumentTemplateService>();
        services.AddSingleton<MigrateAllDocumentsTemplatesService>();

        services.AddSingleton<CreateDocumentByClassificationService>();
        services.AddSingleton<CreateDocumentByTemplateService>();
        services.AddSingleton<GetAllDocumentsService>();
        services.AddSingleton<GetDocumentService>();
        services.AddSingleton<GetDocumentsCountService>();
        services.AddSingleton<SearchDocumentsQuickFiltersService>();

        ConfigureGetDocument(services);

        services.AddSingleton<UpdateDocumentService>();
        services.AddSingleton<UpdateDocumentsClerksService>();
        services.AddSingleton<UpdateDocumentsStatusesService>();
        services.AddSingleton<ValidateDocumentService>();
        services.AddSingleton<ProcessAllDocumentsService>();

        services.AddSingleton<GetAllDocumentsAttributesRolesService>();

        // services.AddSingleton<GetDocumentExternalLinkUrlService>();

        services.AddSingleton<GetDefaultDocumentsStatusesParametersByStatusTypeService>();

        services.AddSingleton<GetAllDocumentSystemAttributesService>();

        services.AddSingleton<GetDocumentRegistryRolesService>();
        services.AddSingleton<GetAllDocumentDomainsService>();
        services.AddSingleton<GetAllDocumentsAttributesDocumentRegistryRolesService>();

        services.AddSingleton<GetReferencesTypesService>();
        services.AddSingleton<GetReferencesTypeValuesSearchService>();
        services.AddSingleton<GetAllReferenceService>();
        services.AddSingleton<GetReferenceService>();
        services.AddSingleton<CreateReferenceService>();
        services.AddSingleton<UpdateReferenceService>();
        services.AddSingleton<GetNewReferenceTypeIdService>();
        services.AddSingleton<GetAllReferenceValuesService>();
        services.AddSingleton<GetReferenceValueService>();
        services.AddSingleton<CreateReferenceValueService>();
        services.AddSingleton<UpdateReferenceValueService>();
        services.AddSingleton<UploadReferenceValueService>();

        services.AddTransient<DocumentDetailedBffEnricher>();
        services.AddTransient<GetAllDocumentsQueryResponseDocumentBffEnricher>();
        services.AddTransient<ReferencesEnricher>();

        services.AddSingleton<GetBusinessSegmentsService>();
        services.AddSingleton<GetDocumentCategoriesService>();
        services.AddSingleton<GetDocumentTypesService>();
        services.AddSingleton<GetDocumentKindsService>();

        services.AddSingleton<GetCountersService>();
        services.AddSingleton<GetCounterService>();
        services.AddSingleton<CreateCounterService>();
        services.AddSingleton<UpdateCounterService>();

        services.AddSingleton<AddParticipantDocumentWorkflowApprovalActionService>();
        services.AddSingleton<CompleteDocumentWorkflowApprovalActionService>();
        services.AddSingleton<DelegateDocumentWorkflowApprovalActionService>();
        services.AddSingleton<TakeInWorkDocumentWorkflowApprovalActionService>();

        services.AddSingleton<GetDelegateDetailsDocumentWorkflowApprovalDetailsService>();
        services.AddSingleton<GetAddParticipantDetailsDocumentWorkflowApprovalDetailsService>();

        services.AddSingleton<GetDocumentsToSignDocumentWorkflowSigningActionService>();
        services.AddSingleton<CancelDocumentWorkflowSigningActionService>();
        services.AddSingleton<PutIntoEffectDocumentWorkflowSigningActionService>();
        services.AddSingleton<ReturnToReworkDocumentWorkflowSigningActionService>();
        services.AddSingleton<SendToContractorDocumentWorkflowSigningActionService>();
        services.AddSingleton<SignDocumentWorkflowSigningActionService>();
        services.AddSingleton<WithdrawByContractorDocumentWorkflowSigningActionService>();
        services.AddSingleton<WithdrawBySelfDocumentWorkflowSigningActionService>();

        services.AddSingleton<GetElectronicDetailsDocumentWorkflowSigningDetailsService>();
        services.AddSingleton<GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsService>();

        services.AddSingleton<IEnricherSource, AttributesPermissionsEnricherSource>();

        services.AddSingleton<IAttributesUserPermissionsCollector, DefaultAttributesUserPermissionsCollector>();
        services.AddSingleton<IAttributesUserPermissionsCollector, SignatoryAttributesUserPermissionsCollector>();
    }

    private static void ConfigureGetDocument(IServiceCollection services)
    {
        services.AddSingleton<ApprovalWorkflowDocumentWorkflowsFetcher>();
        services.AddSingleton<SigningWorkflowDocumentWorkflowsFetcher>();
        services.AddSingleton<DocumentWorkflowsService>();

        services.AddSingleton<ApprovalWorkflowAvailableActionsFetcher>();
        services.AddSingleton<SigningWorkflowAvailableActionsFetcher>();
        services.AddSingleton<DocumentAvailableActionsService>();
    }
}
