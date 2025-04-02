using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;

namespace Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses.Contracts.Queries;

public sealed record GetDocumentsAllowedStatusesResponseBff(DocumentStatusBff[] Statuses);
