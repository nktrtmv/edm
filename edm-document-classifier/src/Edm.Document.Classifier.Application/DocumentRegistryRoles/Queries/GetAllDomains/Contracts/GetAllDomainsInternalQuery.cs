using MediatR;

namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;

public sealed record GetAllDomainsInternalQuery : IRequest<GetAllDomainsInternalResponse>
{
    public static readonly GetAllDomainsInternalQuery Instance = new GetAllDomainsInternalQuery();
}
