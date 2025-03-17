namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;

public enum DocumentAttributeDocumentRole
{
    None = 0,

    DocumentName = 1,
    DocumentDate = 2,
    DocumentNumber = 3,

    DocumentRegistrationNumber = 4,

    /// <summary>
    ///     Автор
    /// </summary>
    DocumentAuthor = 5,

    /// <summary>
    ///     Исполнитель
    /// </summary>
    DocumentClerk = 6,

    /// <summary>
    ///     Ответственный
    /// </summary>
    DocumentResponsible = 7,

    BusinessSegment = 16,
    DocumentCategory = 13,
    DocumentType = 14,
    DocumentKind = 15,

    SigningType = 8,
    SigningPartySelf = 9,
    SigningPartyContractor = 10,
    SigningSignatory = 11,
    SigningDocumentsToSign = 12
}
