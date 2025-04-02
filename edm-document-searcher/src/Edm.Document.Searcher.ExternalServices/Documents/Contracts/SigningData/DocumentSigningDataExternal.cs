using Edm.Document.Searcher.ExternalServices.Documents.Contracts.SigningData.Workflows;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.SigningData;

public sealed record DocumentSigningDataExternal(DocumentSigningWorkflowExternal[] Workflows);
