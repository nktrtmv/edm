using Edm.Document.Classifier.Domain;

namespace Edm.Document.Classifier.ExternalServices.Documents.Contracts;

public sealed class DocumentDetailsEx : ITypedReference
{
    public DocumentDetailsEx(string id, string registrationNumber, string stageType)
    {
        Id = id;
        RegistrationNumber = registrationNumber;
        StageType = stageType;
    }

    public string Id { get; }
    public string RegistrationNumber { get; }
    public string StageType { get; }
}
