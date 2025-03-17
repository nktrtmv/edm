namespace Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentRoles;

public interface IDocumentRolesClient
{
    Task<List<DocumentRoleExternal>> GetDocumentRoles(string domainId, CancellationToken cancellationToken);
}
