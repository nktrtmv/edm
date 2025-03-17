using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Converters.Commands.Contexts;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Converters.Commands.DocumentsWithSignatures;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Converters.Queries.GetDocumentsToSign;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Services.GetDocumentsToSign;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.Contexts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.DocumentsWithSignatures;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Queries.GetDocumentsToSign;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions;

internal sealed class SigningWorkflowsActionsClient : ISigningWorkflowsActionsClient
{
    public SigningWorkflowsActionsClient(SigningActionsService.SigningActionsServiceClient actions, GetDocumentsToSignSigningWorkflowActionService getDocumentsToSign)
    {
        Actions = actions;
        GetDocumentsToSign = getDocumentsToSign;
    }

    private SigningActionsService.SigningActionsServiceClient Actions { get; }
    private GetDocumentsToSignSigningWorkflowActionService GetDocumentsToSign { get; }

    async Task<GetDocumentsToSignSigningWorkflowActionQueryResponseExternal> ISigningWorkflowsActionsClient.GetDocumentsToSign(
        GetDocumentsToSignSigningWorkflowActionQueryExternal query,
        CancellationToken cancellationToken)
    {
        var request =
            GetDocumentsToSignSigningWorkflowActionQueryExternalConverter.ToDto(query);

        var response =
            await GetDocumentsToSign.Get(request, cancellationToken);

        var result =
            GetDocumentsToSignSigningWorkflowActionQueryResponseExternalConverter.FromDto(response);

        return result;
    }

    async Task ISigningWorkflowsActionsClient.Cancel(SigningWorkflowActionContextExternal contextExternal, string comment, CancellationToken cancellationToken)
    {
        var context = SigningWorkflowActionContextExternalConverter.ToDto(contextExternal);

        var request = new CancelSigningActionCommand
        {
            Context = context,
            Comment = comment
        };

        await Actions.CancelAsync(request, cancellationToken: cancellationToken);
    }

    async Task ISigningWorkflowsActionsClient.PutIntoEffect(SigningWorkflowActionContextExternal contextExternal, CancellationToken cancellationToken)
    {
        var context = SigningWorkflowActionContextExternalConverter.ToDto(contextExternal);

        var request = new PutIntoEffectSigningActionCommand
        {
            Context = context
        };

        await Actions.PutIntoEffectAsync(request, cancellationToken: cancellationToken);
    }

    async Task ISigningWorkflowsActionsClient.ReturnToRework(SigningWorkflowActionContextExternal contextExternal, string comment, CancellationToken cancellationToken)
    {
        var context = SigningWorkflowActionContextExternalConverter.ToDto(contextExternal);

        var request = new ReturnToReworkSigningActionCommand
        {
            Context = context,
            Comment = comment
        };

        await Actions.ReturnToReworkAsync(request, cancellationToken: cancellationToken);
    }

    async Task ISigningWorkflowsActionsClient.SendToContractor(SigningWorkflowActionContextExternal contextExternal, CancellationToken cancellationToken)
    {
        var context = SigningWorkflowActionContextExternalConverter.ToDto(contextExternal);

        var request = new SendToContractorSigningActionCommand
        {
            Context = context
        };

        await Actions.SendToContractorAsync(request, cancellationToken: cancellationToken);
    }

    async Task ISigningWorkflowsActionsClient.Sign(
        SigningWorkflowActionContextExternal contextExternal,
        SigningWorkflowDocumentWithSignatureExternal[] documentsBff,
        CancellationToken cancellationToken)
    {
        var context = SigningWorkflowActionContextExternalConverter.ToDto(contextExternal);

        SigningDocumentWithSignatureDto[] documents = documentsBff.Select(SigningWorkflowDocumentWithSignatureExternalConverter.ToDto).ToArray();

        var request = new SignSigningActionCommand
        {
            Context = context,
            Documents = { documents }
        };

        await Actions.SignAsync(request, cancellationToken: cancellationToken);
    }

    async Task ISigningWorkflowsActionsClient.WithdrawByContractor(
        SigningWorkflowActionContextExternal contextExternal,
        string comment,
        CancellationToken cancellationToken)
    {
        var context = SigningWorkflowActionContextExternalConverter.ToDto(contextExternal);

        var request = new WithdrawByContractorSigningActionCommand
        {
            Context = context,
            Comment = comment
        };

        await Actions.WithdrawByContractorAsync(request, cancellationToken: cancellationToken);
    }

    async Task ISigningWorkflowsActionsClient.WithdrawBySelf(SigningWorkflowActionContextExternal contextExternal, string comment, CancellationToken cancellationToken)
    {
        var context = SigningWorkflowActionContextExternalConverter.ToDto(contextExternal);

        var request = new WithdrawBySelfSigningActionCommand
        {
            Context = context,
            Comment = comment
        };

        await Actions.WithdrawBySelfAsync(request, cancellationToken: cancellationToken);
    }
}
