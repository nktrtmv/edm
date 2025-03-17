namespace Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses.Contracts.Commands;

public sealed record UpdateDocumentsStatusesCommandBff(string DomainId, string[] DocumentIds, string NewStatusId);
