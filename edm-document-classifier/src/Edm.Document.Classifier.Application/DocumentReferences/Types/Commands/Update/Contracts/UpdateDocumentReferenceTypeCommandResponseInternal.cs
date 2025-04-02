using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Commands.Update.Contracts;

public sealed record UpdateDocumentReferenceTypeCommandResponseInternal(Id<DocumentReferenceTypeId> ReferenceTypeId);
