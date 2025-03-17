using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.DocumentsSystemAttributes.Queries.GetAll.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsSystemAttributes.Queries.GetAll;

public sealed class GetAllDocumentSystemAttributesService(
    DocumentSystemAttributesService.DocumentSystemAttributesServiceClient systemAttributesService,
    IRoleAdapter roleAdapter) : DocumentSystemAttributesServiceClientBase(systemAttributesService)
{
    public async Task<GetAllDocumentSystemAttributesQueryBffResponse> GetAll(GetAllDocumentSystemAttributesQueryBff query, CancellationToken cancellationToken)
    {
        var request = new GetAllDocumentSystemAttributesQuery { DomainId = query.DomainId };

        var response = await SystemAttributesService.GetAllAsync(request, cancellationToken: cancellationToken);

        var roles = await roleAdapter.GetDomainRoles(query.DomainId, cancellationToken);
        var result =
            GetAllDocumentSystemAttributesQueryBffResponseConverter.FromInternal(roles, response);

        return result;
    }
}
