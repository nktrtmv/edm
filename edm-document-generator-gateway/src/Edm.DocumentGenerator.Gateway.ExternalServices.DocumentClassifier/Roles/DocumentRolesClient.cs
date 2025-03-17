using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes.AttributesTypes;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Converters.DocumentsAttributes.Types;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.Roles;

internal sealed class DocumentRolesClient(DocumentRolesService.DocumentRolesServiceClient serviceClient) : IDocumentsRolesClient
{
    public async Task<List<(DocumentAttributeTypeExternal, DocumentRoleExternal[])>> GetAll(string domainId, CancellationToken cancellationToken)
    {
        var query = new GetAllDocumentRoles.Types.Request
        {
            DomainId = domainId
        };

        var response = await serviceClient.GetAllAsync(query, cancellationToken: cancellationToken);

        List<(DocumentAttributeTypeExternal, DocumentRoleExternal[])> result = response.Items.Select(ToTuple).ToList();

        return result;
    }

    private static (DocumentAttributeTypeExternal attribute, DocumentRoleExternal[] roles) ToTuple(GetAllDocumentRoles.Types.ResponseItem x)
    {
        var attribute = DocumentAttributeTypeExternalConverter.FromDto(x.Attribute);

        DocumentRoleExternal[] roles = x.Roles.Select(y => new DocumentRoleExternal(y.Id, y.Name, y.Display)).ToArray();

        return (attribute, roles);
    }
}
