using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains;
using Edm.Document.Classifier.Domain.Entities.DocumentDomains;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains;

public static class DocumentDomainSettingsInternalConverter
{
    private static DocumentSettingsInternal ToInternal(DocumentsSettings model)
    {
        var result = new DocumentSettingsInternal(
            model.DisableManualCreation,
            model.RegistryTitle.Value,
            model.DetailsTitle.Value,
            model.CreationTitle.Value);

        return result;
    }

    private static CommentsSettingsInternal ToInternal(CommentsSettings model)
    {
        var result = new CommentsSettingsInternal(model.EntityType.Value);

        return result;
    }

    public static DocumentDomainInternal ToInternal(DocumentDomain model)
    {
        var documentSettings = ToInternal(model.DocumentsSettings);

        var commentSettings = ToInternal(model.CommentsSettings);

        var result = new DocumentDomainInternal(
            model.Id.Value,
            model.Name.Value,
            model.DocumentCreationType,
            documentSettings,
            commentSettings,
            model.UrlAlias.Value);

        return result;
    }
}
