namespace Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses.Contracts.Queries;

public sealed record GetDocumentsAllowedStatusesQueryBff(string DomainId, string[] DocumentIds);
