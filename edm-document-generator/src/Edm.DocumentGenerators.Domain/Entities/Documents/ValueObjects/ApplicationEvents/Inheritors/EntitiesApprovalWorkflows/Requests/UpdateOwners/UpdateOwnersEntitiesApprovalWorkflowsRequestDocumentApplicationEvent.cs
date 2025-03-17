using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.UpdateOwners;

public sealed record UpdateOwnersEntitiesApprovalWorkflowsRequestDocumentApplicationEvent(Id<User> OwnerId) : EntitiesApprovalWorkflowsRequestDocumentApplicationEvent;
