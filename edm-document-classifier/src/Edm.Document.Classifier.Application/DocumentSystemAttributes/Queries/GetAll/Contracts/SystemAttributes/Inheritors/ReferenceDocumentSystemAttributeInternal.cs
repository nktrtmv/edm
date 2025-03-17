using Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts.SystemAttributes.Abstractions.Data;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;

namespace Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts.SystemAttributes.Inheritors;

public sealed record ReferenceDocumentSystemAttributeInternal(
    DocumentSystemAttributeDataInternal Data,
    DocumentReferenceTypeId ReferenceId) : DocumentSystemAttributeInternal(Data);
