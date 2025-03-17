namespace Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.Factories;

public static class DocumentReferenceValueFactory
{
    public static DocumentReferenceValue CreateFrom<T>(T id, string displayValue) where T : Enum
    {
        var referenceValueId = Convert.ToInt32(id).ToString();

        var result = new DocumentReferenceValue(referenceValueId, displayValue, string.Empty, EmptyReference.Instance);

        return result;
    }

    public static DocumentReferenceValue CreateFrom(string id, string displayValue, string? displaySubValue = null)
    {
        var result = new DocumentReferenceValue(id, displayValue, displaySubValue ?? string.Empty, EmptyReference.Instance);

        return result;
    }
}
