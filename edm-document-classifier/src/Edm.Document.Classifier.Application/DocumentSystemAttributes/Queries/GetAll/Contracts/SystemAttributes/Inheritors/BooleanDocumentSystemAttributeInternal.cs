using Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts.SystemAttributes.Abstractions.Data;

namespace Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts.SystemAttributes.Inheritors;

public sealed record BooleanDocumentSystemAttributeInternal(DocumentSystemAttributeDataInternal Data) : DocumentSystemAttributeInternal(Data);
