using Edm.Document.Searcher.ExternalServices.Documents.Contracts.SigningData.Workflows.Status;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.SigningData.Workflows;

public sealed record DocumentSigningWorkflowExternal(Id<DocumentSigningWorkflowExternal> Id, DocumentSigningWorkflowStatusExternal Status);
