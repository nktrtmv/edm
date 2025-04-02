using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Preparers.Publish.Converters.Rules;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.Strings;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Routes;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Preparers.Abstractions;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Preparers.Publish.EntitiesApprovalWorkflows.Requests;

internal sealed class CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEventPreparer
    : ApplicationEventPreparerGeneric<Document, CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEvent>
{
    public CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEventPreparer(
        IEntitiesApprovalRulesClient rules,
        ILogger<CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEventPreparer> logger)
        : base(logger)
    {
        Rules = rules;
    }

    private IEntitiesApprovalRulesClient Rules { get; }

    protected override async Task OnPrepare(
        CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEvent applicationEvent,
        Document document,
        CancellationToken cancellationToken)
    {
        EntitiesApprovalRuleEntityExternal? entity = EntitiesApprovalRuleEntityExternalConverter.FromDomain(document);

        string? graphTag = StringStatusParameterDetector.GetTrimmedValueOrEmpty(document.Status, DocumentStatusParameterKind.ApprovalGraphTag);

        EntitiesApprovalRuleRouteExternal? response = await Rules.FindRoute(entity, graphTag, cancellationToken);

        Bytes<DocumentApprovalRoute> route = BytesConverterFrom<DocumentApprovalRoute>.From(response.FindRouteResponse);

        applicationEvent.SetFindRouteResponse(route);
    }
}
