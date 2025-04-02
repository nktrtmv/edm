using System.Text.Json;
using System.Text.Json.Serialization;

using Edm.Document.Classifier.Domain.Entities.DocumentDomains;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.Factories;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;
using Edm.Document.Classifier.Infrastructure.Repositories.Domains.Contracts;

using Microsoft.Extensions.Configuration;

using FilterSettings = Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains.FilterSettings;

namespace Edm.Document.Classifier.Infrastructure.Repositories.Domains;

internal sealed class FileDomainRepository(IConfiguration configuration, IReferenceServicesProvider referencesProvider) : IDomainRepository
{
    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
    {
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
        Converters = { new JsonStringEnumConverter() },
        ReadCommentHandling = JsonCommentHandling.Skip
    };

    private DocumentDomains? _domains;

    public async Task<DocumentDomains> GetAllDomains(CancellationToken cancellationToken)
    {
        var result = _domains ??= await UpdateDomains(cancellationToken);

        return result;
    }

    public async Task<DocumentDomain?> GetDomainById(DomainId id, CancellationToken cancellationToken)
    {
        var domains = await GetAllDomains(cancellationToken);

        var result = domains.Value.FirstOrDefault(x => x.Id == id);

        return result;
    }

    public async Task<DocumentDomain> GetDomainByIdRequired(DomainId id, CancellationToken cancellationToken)
    {
        var domain = await GetDomainById(id, cancellationToken);

        if (domain == null)
        {
            throw new ApplicationException($"Domain with {id.Value} wasn't found");
        }

        return domain;
    }

    private async Task<DocumentDomains> UpdateDomains(CancellationToken cancellationToken)
    {
        var references = referencesProvider.BuildReferencesBySearchType();

        var directory = Path.Join(Environment.CurrentDirectory, "Domains");

        List<string> paths = Directory.GetFiles(directory).Where(x => !x.EndsWith("schema.json")).ToList();

        List<Task<DocumentDomain>> domainTasks = [];

        foreach (var filePath in paths)
        {
            var domainTask = Task.Run(
                async () =>
                {
                    try
                    {
                        var result = await ProcessConfig(cancellationToken, configuration, filePath, references);

                        return result;
                    }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException($"Problem with file {filePath}", e);
                    }
                },
                cancellationToken);

            domainTasks.Add(domainTask);
        }

        var domains = await Task.WhenAll(domainTasks);
        var result = DocumentDomains.Parse(domains.ToList());

        return result;
    }

    private static async Task<DocumentDomain> ProcessConfig(
        CancellationToken cancellationToken,
        IConfiguration configuration,
        string file,
        Dictionary<DocumentReferenceTypeId, DocumentReferenceSearchKind> references)
    {
        var content = await File.ReadAllTextAsync(file, cancellationToken);

        var unvalidatedDomain = JsonSerializer.Deserialize<UnvalidatedDomain>(content, Options)
            ?? throw new ArgumentNullException(content, "Null deserialization result");

        var domain = ConvertToDomain(unvalidatedDomain, references);

        return domain;
    }

    private static DocumentDomain ConvertToDomain(
        UnvalidatedDomain model,
        Dictionary<DocumentReferenceTypeId, DocumentReferenceSearchKind> references)
    {
        var domainName = DomainName.Parse(model.Name!);
        var domainId = DomainId.Parse(model.Id!);
        var urlAlias = UrlAlias.Parse(model.UrlAlias!);

        var registryRoles = model.RegistryRoles?.Select(x => ConvertToDomain(x, references)).ToList() ?? [];
        var systemAttributes = model.SystemAttributes?.Select(ConvertToDomain).ToList() ?? [];
        var documentRoles = model.DocumentRoles?.Select(ConvertToDomain).ToList() ?? [];
        var documentActions = model.DocumentActions ?? [];

        if (model.DocumentsSettings == null)
        {
            throw new ApplicationException("DocumentsSettings can't be null");
        }

        var documentsSettings = ConvertToDomain(model.DocumentsSettings);

        var commentsSettings = ConvertToDomain(model.CommentsSettings, model.Id!);

        var result = DocumentDomain.Parse(
            domainId,
            domainName,
            model.ShowInProduction,
            model.DocumentCreationType,
            registryRoles,
            systemAttributes,
            documentRoles,
            documentActions,
            documentsSettings,
            commentsSettings,
            urlAlias);

        return result;
    }

    private static DocumentsSettings ConvertToDomain(UnvalidatedDocumentsSettings model)
    {
        var registryTitle = DisplayName.Parse(model.RegistryTitle!);
        var detailsTitle = DisplayName.Parse(model.DetailsTitle!);
        var creationTitle = DisplayName.Parse(model.CreationTitle!);
        var result = new DocumentsSettings(model.DisableManualCreation, registryTitle, detailsTitle, creationTitle);

        return result;
    }

    private static CommentsSettings ConvertToDomain(UnvalidatedCommentsSettings? model, string domainId)
    {
        var entityTypeValue = model?.EntityType ?? domainId;

        var entityType = EntityType.Parse(entityTypeValue);

        var result = new CommentsSettings(entityType);

        return result;
    }

    private static DocumentDomainDocumentRole ConvertToDomain(UnvalidatedDocumentRole model)
    {
        var documentRoleId = DocumentRoleId.Parse(model.Id);
        var documentRoleName = DocumentRoleName.Parse(model.Name!);
        var displayName = DisplayName.Parse(model.Display!);

        List<AllowedAttributeCondition> allowedAttributesConditions = model.MarkAttributeWithRoleConditions?.Select(ConvertToDomain).ToList() ?? [];
        var result = new DocumentDomainDocumentRole(documentRoleId, documentRoleName, displayName, allowedAttributesConditions);

        return result;
    }

    private static DocumentDomainRegistryRole ConvertToDomain(
        UnvalidatedDomainRegistryRole model,
        Dictionary<DocumentReferenceTypeId, DocumentReferenceSearchKind> referenceSearchKindById)
    {
        var id = RegistryRoleId.Parse(model.Id);
        var kind = Enum.Parse<DocumentRegistryRoleKind>(model.Kind!);
        var systemName = SystemName.ParseOrNull(model.SystemName!);

        var displayName = DisplayName.Parse(model.Display!);
        var name = RegistryRoleName.Parse(model.Name!);

        if (model.FilterSettings == null)
        {
            throw new ArgumentException($"For domain registry role with id {model.Id} filter settings can't be null");
        }

        if (model.RegistrySettings == null)
        {
            throw new ArgumentException($"For domain registry role with id {model.Id} registry settings can't be null");
        }

        var order = Order.ParseOrNull(model.FilterSettings.Order);

        var filterSettings = FilterSettings.Parse(
            model.FilterSettings.AllowForSearch,
            model.FilterSettings.ShowInFilters,
            model.FilterSettings.AllowMultipleValues,
            model.FilterSettings.SearchKind,
            order);

        var registrySettings = RegistrySettings.Parse(model.RegistrySettings.ShowInRegistry, model.RegistrySettings.ShowByDefault);

        var typeSettingsSettings = ConvertToDomain(model.TypeSettings ?? throw new ArgumentNullException(nameof(model.TypeSettings)));
        List<AllowedAttributeCondition> additionAllowedAttributesConditions =
            model.AdditionMarkAttributeWithRoleConditions?.Select(ConvertToDomain).ToList() ?? [];

        var result = DocumentDomainRegistryRole.Parse(
            id,
            name,
            displayName,
            kind,
            systemName,
            registrySettings,
            filterSettings,
            typeSettingsSettings,
            additionAllowedAttributesConditions,
            referenceSearchKindById);

        return result;
    }

    private static DocumentDomainSystemAttribute ConvertToDomain(UnvalidatedSystemAttribute model)
    {
        var id = SystemAttributeId.Parse(model.Id);
        var systemName = SystemName.Parse(model.SystemName!);
        var displayName = DisplayName.Parse(model.Display!);

        var registryRoleTypeSettingsSettings = ConvertToDomain(model.TypeSettings ?? throw new ArgumentNullException(nameof(model.TypeSettings)));
        var registryRoleIds = model.RegistryRolesIds?.Select(RegistryRoleId.Parse).ToHashSet() ?? [];
        var documentRoleIds = model.DocumentRolesIds?.Select(DocumentRoleId.Parse).ToHashSet() ?? [];
        var result = new DocumentDomainSystemAttribute(id, displayName, systemName, model.IsArray, registryRoleTypeSettingsSettings, registryRoleIds, documentRoleIds);

        return result;
    }

    private static AllowedAttributeCondition ConvertToDomain(UnvalidatedMarkAttributeWithRoleCondition model)
    {
        return model switch
        {
            UnvalidatedReferenceMarkAttributeWithRoleCondition r => ReferenceAllowedAttributeCondition.Parse((DocumentReferenceTypeId)r.ReferenceId),
            UnvalidatedStringMarkAttributeWithRoleCondition => new StringAllowedAttributeCondition(),
            UnvalidatedBooleanMarkAttributeWithRoleCondition => new BooleanAllowedAttributeCondition(),
            UnvalidatedNumberMarkAttributeWithRoleCondition => new NumberAllowedAttributeCondition(),
            UnvalidatedAttachmentMarkAttributeWithRoleCondition => new AttachmentAllowedAttributeCondition(),
            UnvalidatedDateMarkAttributeWithRoleCondition => new DateAllowedAttributeCondition(),
            _ => throw new ArgumentOutOfRangeException(nameof(model))
        };
    }

    private static TypeSettings ConvertToDomain(UnvalidatedTypeSettings model)
    {
        return model switch
        {
            UnvalidatedStringTypeSettings => new StringTypeSettings(),
            UnvalidatedAttachmentTypeSettings => new AttachmentTypeSettings(),
            UnvalidatedBooleanTypeSettings => new BooleanTypeSettings(),
            UnvalidatedNumberTypeSettings t => new NumberTypeSettings(t.Precision),
            UnvalidatedDateTypeSettings t => DateTypeSettings.Parse(t.DisplayType),
            UnvalidatedReferenceTypeSettings t => ReferenceTypeSettings.Parse((DocumentReferenceTypeId)t.ReferenceId, t.DisplayType),
            _ => throw new ArgumentOutOfRangeException(nameof(model))
        };
    }
}
