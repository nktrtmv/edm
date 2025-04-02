using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Statuses;

internal static class SigningStatusDbConverter
{
    internal static SigningStatusDb FromDomain(SigningStatus status)
    {
        SigningStatusDb result = status switch
        {
            SigningStatus.NotStarted => SigningStatusDb.NotStarted,
            SigningStatus.InProgress => SigningStatusDb.InProgress,
            SigningStatus.Completed => SigningStatusDb.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static SigningStatus ToDomain(SigningStatusDb status)
    {
        SigningStatus result = status switch
        {
            SigningStatusDb.NotStarted => SigningStatus.NotStarted,
            SigningStatusDb.InProgress => SigningStatus.InProgress,
            SigningStatusDb.Completed => SigningStatus.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
