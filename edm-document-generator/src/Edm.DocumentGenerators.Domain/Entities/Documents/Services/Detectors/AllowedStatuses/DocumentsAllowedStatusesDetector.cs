using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Results;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.AllowedStatuses;

public static class DocumentsAllowedStatusesDetector
{
    public static (HashSet<DocumentStatus> Statuses, BusinessLogicApplicationException? Exception) Detect(Document[] documents)
    {
        bool documentsHasDifferentTemplates = documents.Select(d => d.TemplateId).Distinct().Count() > 1;

        if (documentsHasDifferentTemplates)
        {
            var exception = new BusinessLogicApplicationException("Document has different templates");

            return ([], exception);
        }

        HashSet<DocumentStatus> result = documents
            .Select(GetDocumentAvailableStatuses)
            .Aggregate((l1, l2) => l1.Intersect(l2, DocumentStatusComparer.Instance))
            .ToHashSet(DocumentStatusComparer.Instance);

        if (result.Count == 0)
        {
            var exception = new BusinessLogicApplicationException("Available statuses was not found.");

            return ([], exception);
        }

        return (result, null);
    }

    private static IEnumerable<DocumentStatus> GetDocumentAvailableStatuses(Document document)
    {
        DocumentStatusTransition[] availableTransitions = document.StatusStateMachine.GetAvailableTransitionsForStatus(document.Status.Id);

        DocumentStatus[] statusesTo = availableTransitions.Select(t => t.To).ToArray();

        foreach (DocumentStatus statusTo in statusesTo)
        {
            var validateParameters = new DocumentValidateParameters(document, statusTo.Id, document.AttributesValues);

            DocumentValidatorValidationResult[] validationResult =
                DocumentValidatorByValidators.GetValidationResults(validateParameters);

            if (validationResult.Any(r => r.IsFailed()))
            {
                continue;
            }

            yield return statusTo;
        }
    }

    private sealed class DocumentStatusComparer : IEqualityComparer<DocumentStatus>
    {
        public static readonly DocumentStatusComparer Instance = new DocumentStatusComparer();

        public bool Equals(DocumentStatus? x, DocumentStatus? y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }

            bool result = x.Id == y.Id &&
                x.Type == y.Type &&
                x.DisplayName == y.DisplayName;

            return result;
        }

        public int GetHashCode(DocumentStatus obj)
        {
            return HashCode.Combine(obj.Id, (int)obj.Type, obj.DisplayName);
        }
    }
}
