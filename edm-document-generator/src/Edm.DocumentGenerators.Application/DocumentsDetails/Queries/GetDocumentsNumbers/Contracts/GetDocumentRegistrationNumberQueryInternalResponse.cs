namespace Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsNumbers.Contracts;

public sealed class GetDocumentRegistrationNumberQueryInternalResponse
{
    internal GetDocumentRegistrationNumberQueryInternalResponse(string? registrationNumber)
    {
        RegistrationNumber = registrationNumber;
    }

    public string? RegistrationNumber { get; }
}
