using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.Created;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values;

[JsonDerivedType(typeof(DocumentAttributesValuesChangedAuditRecordBff), "AttributesValuesChanged")]
[JsonDerivedType(typeof(DocumentCreatedAuditRecordBff), "Created")]
[JsonDerivedType(typeof(DocumentStatusChangedAuditRecordBff), "StatusChanged")]
public abstract class DocumentAuditRecordValueBff
{
}
