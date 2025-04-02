namespace Edm.DocumentGenerators.Domain;

public interface IRoleAdapter
{
    Task WarmUp(CancellationToken cancellationToken);
    string GetDocumentRoleDisplayById(string domainId, int id);
}
