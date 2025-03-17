using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts.Context;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts;

public abstract record ActionsCommandInternal(ApprovalWorkflowActionContextInternal Context, bool DryRunAndLock) : IRequest;
