namespace Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsClerks.Contracts.Commands;

public sealed record UpdateDocumentsClerksCommandBff(string DomainId, string[] DocumentIds, string NewClerkId);
