using Edm.DocumentGenerators.Application.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts;
using Edm.DocumentGenerators.Application.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts.ParametersByStatusType;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentStatusParameters;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType;

[UsedImplicitly]
internal sealed class GetDefaultDocumentsStatusesParametersByStatusTypeHandler
    : IRequestHandler<GetDefaultDocumentsStatusesParametersByStatusTypeQueryInternal, GetDefaultDocumentsStatusesParametersByStatusTypeQueryInternalResponse>
{
    public GetDefaultDocumentsStatusesParametersByStatusTypeHandler(IDocumentsStatusesParametersRepository statusesParameters)
    {
        StatusesParameters = statusesParameters;
    }

    private IDocumentsStatusesParametersRepository StatusesParameters { get; }

    public async Task<GetDefaultDocumentsStatusesParametersByStatusTypeQueryInternalResponse> Handle(
        GetDefaultDocumentsStatusesParametersByStatusTypeQueryInternal request,
        CancellationToken cancellationToken)
    {
        Dictionary<DocumentStatusType, DocumentStatusParameter[]> parametersByStatusType =
            await StatusesParameters.GetParametersByStatusType(cancellationToken);

        DocumentsStatusesParametersByStatusTypeInternal[] parametersByStatusTypeInternal = parametersByStatusType
            .Select(DocumentsStatusesParametersByStatusTypeInternalConverter.FromDomain)
            .ToArray();

        var result = new GetDefaultDocumentsStatusesParametersByStatusTypeQueryInternalResponse(parametersByStatusTypeInternal);

        return result;
    }
}
