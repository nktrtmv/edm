using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Activate.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.CreateNewVersion.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Deactivate.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.Activate;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.CreateNewVersion;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.Deactivate;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.Update;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.Get;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetActivationAudit;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetAll;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetVersions;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.Search;

using Grpc.Core;

using MediatR;

using ApprovalRulesService = Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals.ApprovalRulesService;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules;

internal sealed class ApprovalRulesInternalController(IMediator mediator, ILogger<ApprovalRulesInternalController> logger) : ApprovalRulesService.ApprovalRulesServiceBase
{
    public override async Task<ActivateApprovalRulesCommandResponse> Activate(ActivateApprovalRulesCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Activate),
            command,
            async () =>
            {
                ActivateApprovalRulesCommandInternal request = ActivateApprovalRulesCommandInternalConverter.FromDto(command);

                await mediator.Send(request, context.CancellationToken);

                var result = new ActivateApprovalRulesCommandResponse();

                return result;
            });
    }

    public override async Task<CreateNewVersionApprovalRulesCommandResponse> CreateNewVersion(
        CreateNewVersionApprovalRulesCommand command,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(CreateNewVersion),
            command,
            async () =>
            {
                CreateNewVersionApprovalRulesCommandInternal request = CreateNewVersionApprovalRulesCommandInternalConverter.FromDto(command);

                CreateNewVersionApprovalRulesCommandResponseInternal response = await mediator.Send(request, context.CancellationToken);

                CreateNewVersionApprovalRulesCommandResponse result = CreateNewVersionApprovalRulesCommandResponseInternalConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<DeactivateApprovalRulesCommandResponse> Deactivate(DeactivateApprovalRulesCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Deactivate),
            command,
            async () =>
            {
                DeactivateApprovalRulesCommandInternal request = DeactivateApprovalRulesCommandInternalConverter.FromDto(command);

                await mediator.Send(request, context.CancellationToken);

                var result = new DeactivateApprovalRulesCommandResponse();

                return result;
            });
    }

    public override async Task<UpdateApprovalRulesCommandResponse> Update(UpdateApprovalRulesCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Update),
            command,
            async () =>
            {
                UpdateApprovalRulesCommandInternal request = UpdateApprovalRulesCommandInternalConverter.FromDto(command);

                UpdateApprovalRulesCommandResponseInternal response = await mediator.Send(request, context.CancellationToken);

                UpdateApprovalRulesCommandResponse result = UpdateApprovalRulesCommandResponseInternalConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<GetActivationAuditApprovalRulesQueryResponse> GetActivationAudit(
        GetActivationAuditApprovalRulesQuery query,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetActivationAudit),
            query,
            async () =>
            {
                GetActivationAuditApprovalRulesQueryInternal request = GetActivationAuditApprovalRulesQueryInternalConverter.FromDto(query);

                GetActivationAuditApprovalRulesQueryResponseInternal response = await mediator.Send(request, context.CancellationToken);

                GetActivationAuditApprovalRulesQueryResponse result = GetActivationAuditApprovalRulesQueryResponseInternalConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<GetAllApprovalRulesQueryResponse> GetAll(GetAllApprovalRulesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetAll),
            query,
            async () =>
            {
                GetAllApprovalRulesQueryInternal request = GetAllApprovalRulesQueryInternalConverter.FromDto(query);

                GetAllApprovalRulesQueryResponseInternal response = await mediator.Send(request, context.CancellationToken);

                GetAllApprovalRulesQueryResponse result = GetAllApprovalRulesQueryResponseInternalConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<GetApprovalRuleQueryResponse> Get(GetApprovalRuleQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Get),
            query,
            async () =>
            {
                GetApprovalRuleQueryInternal request = GetApprovalRuleQueryInternalConverter.FromDto(query);

                GetApprovalRuleQueryResponseInternal response = await mediator.Send(request, context.CancellationToken);

                GetApprovalRuleQueryResponse result = GetApprovalRuleQueryResponseInternalConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<GetVersionsApprovalRulesQueryResponse> GetVersions(GetVersionsApprovalRulesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetVersions),
            query,
            async () =>
            {
                GetVersionsApprovalRulesQueryInternal request = GetVersionsApprovalRulesQueryInternalConverter.FromDto(query);

                GetVersionsApprovalRulesQueryResponseInternal response = await mediator.Send(request, context.CancellationToken);

                GetVersionsApprovalRulesQueryResponse result = GetVersionsApprovalRulesQueryResponseInternalConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<SearchApprovalRulesQueryResponse> Search(SearchApprovalRulesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Search),
            query,
            async () =>
            {
                SearchApprovalRulesQueryInternal request = SearchApprovalRulesQueryInternalConverter.FromDto(query);

                SearchApprovalRulesQueryResponseInternal response = await mediator.Send(request, context.CancellationToken);

                SearchApprovalRulesQueryResponse result = SearchApprovalRulesQueryResponseInternalConverter.ToDto(response);

                return result;
            });
    }
}
