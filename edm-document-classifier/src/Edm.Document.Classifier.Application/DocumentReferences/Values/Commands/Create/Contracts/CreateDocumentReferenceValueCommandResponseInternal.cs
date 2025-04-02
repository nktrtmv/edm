using Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Create.Contracts;

public sealed record CreateDocumentReferenceValueCommandResponseInternal(Id<ReferenceValueInternal> Id);
