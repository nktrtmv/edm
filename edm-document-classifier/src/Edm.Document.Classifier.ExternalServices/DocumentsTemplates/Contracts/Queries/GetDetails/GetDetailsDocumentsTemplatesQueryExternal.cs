using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.ExternalServices.DocumentsTemplates.Contracts.Queries.GetDetails;

public sealed record GetDetailsDocumentsTemplatesQueryExternal(Id<DocumentTemplate>[] DocumentTemplateIds);
