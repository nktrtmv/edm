using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.AttributesChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.StatusChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesErrors;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;

public sealed class DocumentUpdateParameters
{
    internal DocumentUpdateParameters(
        DocumentStatusChange? statusChange,
        DocumentAttributesChange? attributesChange,
        DocumentAttributeError[]? attributesErrors,
        string[]? commonErrors)
    {
        StatusChange = statusChange;
        AttributesChange = attributesChange;
        AttributesErrors = attributesErrors;
        CommonErrors = commonErrors;
    }

    internal DocumentStatusChange? StatusChange { get; }
    internal DocumentAttributesChange? AttributesChange { get; }
    internal DocumentAttributeError[]? AttributesErrors { get; }
    internal string[]? CommonErrors { get; }

    public override string ToString()
    {
        string attributesErrors = string.Join<DocumentAttributeError>(", ", AttributesErrors ?? []);

        string commonsErrors = string.Join<string>(", ", CommonErrors ?? []);

        return $"{{ StatusChange: {StatusChange}, AttributesChange: {AttributesChange}, AttributesErrors: [{attributesErrors}], CommonsErrors: [{commonsErrors}] }}";
    }
}
