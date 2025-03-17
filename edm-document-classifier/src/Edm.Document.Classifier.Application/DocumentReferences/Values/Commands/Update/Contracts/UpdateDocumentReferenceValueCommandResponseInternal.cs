using Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Update.Contracts;

public sealed record UpdateDocumentReferenceValueCommandResponseInternal(Id<ReferenceValueInternal> Id);
