using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAllDocumentsStatuses.Converters;

internal static class GetAllDocumentsStatusesDocumentTemplatesQueryResponseStatusConverter
{
    internal static ReferenceTypeValueBff ToBff(string status)
    {
        var result = new ReferenceTypeValueBff
        {
            Id = status,
            DisplayValue = status,
            DisplaySubValue = string.Empty
        };

        return result;
    }
}
