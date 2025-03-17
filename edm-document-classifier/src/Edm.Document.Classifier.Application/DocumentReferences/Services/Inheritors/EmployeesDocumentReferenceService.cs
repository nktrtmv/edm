using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;
using Edm.Document.Classifier.ExternalServices.Employees;
using Edm.Document.Classifier.ExternalServices.Employees.Contracts;

using JetBrains.Annotations;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors;

[UsedImplicitly]
internal sealed class EmployeesDocumentReferenceService(IEmployeesClient employeesClient) : DocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.Employees,
        DocumentReferenceSearchKind.Search,
        DocumentReferenceKind.Employee,
        "Сотрудники");

    public override async Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        var criteria = new EmployeeSearchCriteriaEx(searchParams.Ids.ToArray(), searchParams.Search, searchParams.Skip, searchParams.Limit);

        EmployeeEx[] employees = await employeesClient.Search(criteria, cancellationToken);

        DocumentReferenceValue[] result = employees.Select(
                e => new DocumentReferenceValue(
                    e.Id,
                    $"{e.FullName} ({e.Login})",
                    $"{e.Department}/{e.Position}/{e.Email}",
                    e))
            .ToArray();

        return result;
    }
}
