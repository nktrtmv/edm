using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Commands.Create.Contracts;

public sealed record CreateDocumentReferenceTypeCommandResponseInternal(Id<DocumentReferenceTypeId> ReferencesType);
