using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes;
using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.DocumentsSystemAttributes.Queries.GetAll.Contracts.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsSystemAttributes.Queries.GetAll.Contracts;

internal static class GetAllDocumentSystemAttributesQueryBffResponseConverter
{
    internal static GetAllDocumentSystemAttributesQueryBffResponse FromInternal(
        DomainRoles domainRoles,
        GetAllDocumentSystemAttributesQueryResponse response)
    {
        DocumentAttributeBff[] attributes = response.Attributes.Select(x => DocumentSystemAttributeBffConverter.FromDto(domainRoles, x)).ToArray();

        var result = new GetAllDocumentSystemAttributesQueryBffResponse
        {
            Attributes = attributes
        };

        return result;
    }
}
