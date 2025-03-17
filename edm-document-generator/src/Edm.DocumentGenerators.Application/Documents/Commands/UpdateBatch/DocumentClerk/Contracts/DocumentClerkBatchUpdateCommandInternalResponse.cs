using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentClerk.Contracts;

public sealed record DocumentClerkBatchUpdateCommandInternalResponse(Id<DocumentInternal>[] DocumentIds);
