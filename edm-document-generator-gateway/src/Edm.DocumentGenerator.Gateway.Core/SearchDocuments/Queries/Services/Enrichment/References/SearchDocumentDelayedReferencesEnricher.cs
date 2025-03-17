using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types.Inheritors.References;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Enrichers;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.Enrichment.References;

internal sealed class SearchDocumentDelayedReferencesEnricher : Enricher<GetAllDocumentsQueryResponseDocumentReferenceAttributeValueBff>
{
    private readonly List<GetAllDocumentsQueryResponseDocumentReferenceAttributeValueBff> _values =
        new List<GetAllDocumentsQueryResponseDocumentReferenceAttributeValueBff>();

    internal SearchDocumentDelayedReferencesEnricher(ReferencesEnricher referenceEnricher)
    {
        ReferenceEnricher = referenceEnricher;
    }

    private ReferencesEnricher ReferenceEnricher { get; }

    public override void Add(GetAllDocumentsQueryResponseDocumentReferenceAttributeValueBff value)
    {
        _values.Add(value);
    }

    public override Task Enrich(CancellationToken cancellationToken)
    {
        if (_values.Any())
        {
            throw new InvalidOperationException("Please call DocumentConversionComplete before calling Enrich");
        }

        return Task.CompletedTask;
    }

    public void DocumentConversionComplete(string templateId, DocumentRegistryRoleExternal[] registryRoles)
    {
        AddValuesToReferencesEnricher(templateId, registryRoles);

        _values.Clear();
    }

    private void AddValuesToReferencesEnricher(string templateId, DocumentRegistryRoleExternal[] registryRoles)
    {
        IEnumerable<ReferenceValueWithType> referenceValueWithTypes = GetReferencesValuesWithTypes(templateId, _values, registryRoles);

        AddRangeToReferencesEnricher(referenceValueWithTypes);
    }

    private void AddRangeToReferencesEnricher(IEnumerable<ReferenceValueWithType> referenceValueWithTypes)
    {
        foreach (var referenceValueWithType in referenceValueWithTypes)
        {
            ReferenceEnricher.Add(referenceValueWithType);
        }
    }

    private IEnumerable<ReferenceValueWithType> GetReferencesValuesWithTypes(
        string templateId,
        List<GetAllDocumentsQueryResponseDocumentReferenceAttributeValueBff> attributesValues,
        DocumentRegistryRoleExternal[] registryRoles)
    {
        foreach (var attributeValue in attributesValues)
        {
            var registryRole =
                registryRoles.Single(r => r.Name == attributeValue.RegistryRoleId);

            var referenceType = !string.IsNullOrWhiteSpace(attributeValue.ReferenceType)
                ? attributeValue.ReferenceType
                : ((DocumentReferenceRegistryRoleTypeExternal)registryRole.Type).ReferenceType;

            foreach (var value in attributeValue.Values)
            {
                List<ParentInfo>? parents = attributeValue.Parents?.Select(x => new ParentInfo(x.ReferenceType, x.Values)).ToList();
                var key = new ReferenceTypeKey(referenceType, templateId, parents);

                yield return new ReferenceValueWithType(key, value);
            }
        }
    }
}
