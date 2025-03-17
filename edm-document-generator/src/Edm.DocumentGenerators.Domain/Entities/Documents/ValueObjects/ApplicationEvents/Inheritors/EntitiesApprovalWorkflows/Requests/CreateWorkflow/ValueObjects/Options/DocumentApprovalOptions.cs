using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.
    Options;

public sealed record DocumentApprovalOptions(
    bool ApprovingWithRemarkIsDisabled,
    bool AutoInProgressAssignmentsIsDisabled,
    Id<User>[] WatchersIds);
