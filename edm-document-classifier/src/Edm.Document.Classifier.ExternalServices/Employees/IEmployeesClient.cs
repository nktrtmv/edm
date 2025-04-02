using Edm.Document.Classifier.ExternalServices.Employees.Contracts;

namespace Edm.Document.Classifier.ExternalServices.Employees;

public interface IEmployeesClient
{
    Task<EmployeeEx[]> Search(EmployeeSearchCriteriaEx criteria, CancellationToken cancellationToken);
}
