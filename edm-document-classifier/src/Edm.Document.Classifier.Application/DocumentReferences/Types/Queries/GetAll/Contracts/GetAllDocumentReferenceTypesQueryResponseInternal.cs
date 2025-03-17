using Edm.Document.Classifier.Application.DocumentReferences.Types.Contracts;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetAll.Contracts;

public sealed record GetAllDocumentReferenceTypesQueryResponseInternal(DocumentReferenceTypeResponseInternal[] ReferenceTypes);
