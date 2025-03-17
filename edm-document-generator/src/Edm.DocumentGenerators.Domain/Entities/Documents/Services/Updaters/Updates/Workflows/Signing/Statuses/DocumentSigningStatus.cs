namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Signing.Statuses;

public enum DocumentSigningStatus
{
    None = 0,
    Signed = 1,
    Cancelled = 2,
    ToPreparation = 3,
    ReturnedToRework = 4
}
