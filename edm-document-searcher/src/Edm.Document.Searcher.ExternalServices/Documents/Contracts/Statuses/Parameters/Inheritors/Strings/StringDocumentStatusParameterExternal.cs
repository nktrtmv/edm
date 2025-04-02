namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.Strings;

public sealed class StringDocumentStatusParameterExternal : DocumentStatusParameterExternal
{
    public required string Value { get; init; }
}
