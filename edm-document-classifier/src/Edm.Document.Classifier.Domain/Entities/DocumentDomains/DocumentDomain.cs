using Edm.Document.Classifier.Domain.Entities.DocumentExternalLinks.ValueObjects.Kinds;
using Edm.Document.Classifier.Domain.Extensions;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Domain.Entities.DocumentDomains;

public sealed class DocumentDomain
{
    private DocumentDomain(
        DomainId id,
        DomainName name,
        bool showInProduction,
        DocumentCreationType documentCreationType,
        List<DocumentDomainRegistryRole> registryRoles,
        List<DocumentDomainSystemAttribute> systemAttributes,
        List<DocumentDomainDocumentRole> documentRoles,
        List<DocumentAction> actions,
        DocumentsSettings documentsSettings,
        CommentsSettings commentsSettings,
        UrlAlias urlAlias)
    {
        Id = id;
        Name = name;
        ShowInProduction = showInProduction;
        RegistryRoles = registryRoles;
        DocumentCreationType = documentCreationType;
        SystemAttributes = systemAttributes;
        DocumentRoles = documentRoles;
        Actions = actions;
        DocumentsSettings = documentsSettings;
        CommentsSettings = commentsSettings;
        UrlAlias = urlAlias;
    }

    public DomainId Id { get; private set; }

    public DomainName Name { get; private set; }

    public bool ShowInProduction { get; private set; }

    public DocumentCreationType DocumentCreationType { get; private set; }


    public List<DocumentDomainRegistryRole> RegistryRoles { get; private set; }

    public List<DocumentDomainSystemAttribute> SystemAttributes { get; private set; }

    public List<DocumentDomainDocumentRole> DocumentRoles { get; private set; }

    public List<DocumentAction> Actions { get; private set; }

    public DocumentsSettings DocumentsSettings { get; private set; }

    public CommentsSettings CommentsSettings { get; private set; }

    public UrlAlias UrlAlias { get; private set; }

    public static DocumentDomain Parse(
        DomainId id,
        DomainName domainName,
        bool showInProduction,
        DocumentCreationType documentCreationType,
        List<DocumentDomainRegistryRole> registryRoles,
        List<DocumentDomainSystemAttribute> systemAttributes,
        List<DocumentDomainDocumentRole> documentRoles,
        List<DocumentAction> documentActions,
        DocumentsSettings documentsSettings,
        CommentsSettings commentsSettings,
        UrlAlias urlAlias)
    {
        registryRoles
            .Select(x => x.Id.Value)
            .ToList()
            .ThrowIfNonAllUnique(() => $"In domain {domainName.Value} with id {id.Value} all registry roles must have unique id");

        registryRoles
            .Select(x => x.Name.Value)
            .ToList()
            .ThrowIfNonAllUnique(() => $"In domain {domainName.Value} with id {id.Value} all registry roles must have unique name");

        registryRoles
            .Where(x => x.SystemName != null)
            .Select(x => x.SystemName!.Value.Value)
            .ToList()
            .ThrowIfNonAllUnique(() => $"In domain {domainName.Value} with id {id.Value} all registry roles system name must have unique id");

        systemAttributes
            .Select(x => x.Id.Value)
            .ToList()
            .ThrowIfNonAllUnique(() => $"In domain {domainName.Value} with id {id.Value} all system attribute ids must have unique id");

        systemAttributes
            .Select(x => x.SystemName.Value)
            .ToList()
            .ThrowIfNonAllUnique(() => $"In domain {domainName.Value} with id {id.Value} all system names must have unique id");

        documentRoles
            .Select(x => x.Id.Value)
            .ToList()
            .ThrowIfNonAllUnique(() => $"In domain {domainName.Value} with id {id.Value} all document roles must have unique id");

        documentRoles
            .Select(x => x.Name.Value)
            .ToList()
            .ThrowIfNonAllUnique(() => $"In domain {domainName.Value} with id {id.Value} all document roles must have unique name");

        documentActions
            .Select(a => (int)a)
            .ToList()
            .ThrowIfAnyDefault(() => $"In domain {domainName.Value} with id {id.Value} documents actions must have not default values")
            .ThrowIfNonAllUnique(() => $"In domain {domainName.Value} with id {id.Value} all documents actions must have unique");

        var systemRoleWithWrongRegistryRole = systemAttributes.FirstOrDefault(
            x => x.RegistryRolesIds
                .Any(y => registryRoles.All(r => r.Id != y)));

        var systemRoleWithWrongDocumentRole = systemAttributes.FirstOrDefault(
            x => x.DocumentRoleIds
                .Any(y => documentRoles.All(r => r.Id != y)));

        if (systemRoleWithWrongDocumentRole != null)
        {
            var incorrectId = systemRoleWithWrongDocumentRole.DocumentRoleIds.FirstOrDefault(x => !documentRoles.Select(y => y.Id).Contains(x));

            throw new ApplicationException(
                $"In domain {domainName.Value} with id {id.Value} system role with id {systemRoleWithWrongDocumentRole.Id} have unknown DocumentRoleId {incorrectId.Value}");
        }

        if (systemRoleWithWrongRegistryRole != null)
        {
            var incorrectId = systemRoleWithWrongRegistryRole.RegistryRolesIds.FirstOrDefault(x => !registryRoles.Select(y => y.Id).Contains(x));

            throw new ApplicationException(
                $"In domain {domainName.Value} with id {id.Value} system role with id {systemRoleWithWrongRegistryRole.Id} have unknown RegistryRolesId {incorrectId.Value}");
        }

        if (documentCreationType == DocumentCreationType.None)
        {
            throw new ApplicationException($"In domain {domainName.Value} with id {id.Value} DocumentCreationType can't be none");
        }

        var result = new DocumentDomain(
            id,
            domainName,
            showInProduction,
            documentCreationType,
            registryRoles,
            systemAttributes,
            documentRoles,
            documentActions,
            documentsSettings,
            commentsSettings,
            urlAlias);

        return result;
    }
}
