using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetDocumentsToSign.Contracts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Contexts;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetDocumentsToSign;

internal static class GetSigningDocumentsToSignQueryConverter
{
    internal static GetSigningDocumentsToSignQueryInternal ToInternal(GetSigningDocumentsToSignQuery query)
    {
        SigningActionContextInternal context = SigningActionContextDtoConverter.ToInternal(query.Context);

        var result = new GetSigningDocumentsToSignQueryInternal(context);

        return result;
    }
}
