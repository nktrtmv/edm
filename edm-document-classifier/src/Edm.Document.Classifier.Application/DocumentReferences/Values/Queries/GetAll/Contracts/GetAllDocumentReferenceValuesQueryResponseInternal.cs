using Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.GetAll.Contracts;

public sealed record GetAllDocumentReferenceValuesQueryResponseInternal(ReferenceValueInternal[] Values);
