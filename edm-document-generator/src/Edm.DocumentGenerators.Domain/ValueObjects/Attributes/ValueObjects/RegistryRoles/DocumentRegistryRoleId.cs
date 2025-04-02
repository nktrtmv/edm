namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.RegistryRoles;

public enum DocumentRegistryRoleId
{
    None = 0,
    RegistrationNumber = 1,
    Stage = 2,
    Status = 3,
    CreatedAt = 4,
    UpdatedAt = 5,
    DocumentParticipants = 6,
    DocumentCumulativeParticipants = 7,
    ApprovalParticipants = 8,
    ApprovalCumulativeParticipants = 9,

    Number = 101,
    Date = 102,
    SelfCompany = 103,
    ContractorCompany = 104,
    Name = 105,
    ResponsibleManager = 106,
    Author = 107,
    Clerk = 108,
    BusinessSegment = 109,
    DocumentCategory = 110,
    DocumentType = 111,
    DocumentKind = 112,
    ValidityDate = 113,
    EndDate = 114,
    IsSignedDocumentsScansReceived = 115,
    IsSignedDocumentsOriginalsReceived = 116,
    Currency = 117,
    MetazonId = 118,
    ContractSigningType = 119,
    RetroBonusesConditions = 120,
    OwnBrand = 121,
    ProjectInput = 130,
    MacroBusinessUnit = 131,
    CategoryFirstLevel = 132,
    TemplateType = 133
}
