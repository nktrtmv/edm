namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAllDocumentsStatuses.Contracts;

public sealed class GetAllDocumentsStatusesDocumentTemplatesQueryResponseInternal
{
    internal GetAllDocumentsStatusesDocumentTemplatesQueryResponseInternal(string[] statuses)
    {
        Statuses = statuses;
    }

    public string[] Statuses { get; }
}
