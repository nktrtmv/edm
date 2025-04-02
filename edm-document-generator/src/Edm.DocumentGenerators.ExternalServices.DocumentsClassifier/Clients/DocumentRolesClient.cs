using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentRoles;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients;

internal sealed class DocumentRolesClient(DocumentRolesService.DocumentRolesServiceClient client) : IDocumentRolesClient
{
    public async Task<List<DocumentRoleExternal>> GetDocumentRoles(string domainId, CancellationToken cancellationToken)
    {
        var request = new GetAllDocumentRoles.Types.Request { DomainId = domainId };
        GetAllDocumentRoles.Types.Response? response = await client.GetAllAsync(request, cancellationToken: cancellationToken);

        List<DocumentRoleExternal> result = response.Items.SelectMany(x => x.Roles).Select(x => new DocumentRoleExternal(x.Id, x.Name, x.Display)).ToList();

        return result;
    }
}
