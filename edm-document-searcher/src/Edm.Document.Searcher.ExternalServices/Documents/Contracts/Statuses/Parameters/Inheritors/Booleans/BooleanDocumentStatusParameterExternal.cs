namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.Booleans;

public sealed class BooleanDocumentStatusParameterExternal : DocumentStatusParameterExternal
{
    public required bool Value { get; init; }
}
