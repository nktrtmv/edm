using Edm.Document.Classifier.ExternalServices.Employees.Contracts;

namespace Edm.Document.Classifier.ExternalServices.Employees;

internal sealed class EmployeesClient : IEmployeesClient
{
    private static readonly EmployeeEx[] Employees =
    [
        new EmployeeEx("0", "nartemov", "HSE", "Student", "Артемов Никита Владиславович", "nartemov@hse.ru", 0),
        new EmployeeEx("1", "login_1", "department_1", "position_1", "full_name_1", "email_1", 1),
        new EmployeeEx("2", "login_2", "department_2", "position_2", "full_name_2", "email_2", 2),
        new EmployeeEx("3", "login_3", "department_3", "position_3", "full_name_3", "email_3", 3),
        new EmployeeEx("4", "login_4", "department_4", "position_4", "full_name_4", "email_4", 4)
    ];

    public Task<EmployeeEx[]> Search(EmployeeSearchCriteriaEx criteria, CancellationToken cancellationToken)
    {
        var result = Employees
            .Where(e => criteria.Ids.Length == 0 || criteria.Ids.Contains(e.Id))
            .Where(
                e => string.IsNullOrWhiteSpace(criteria.Query) ||
                    e.Login.Contains(criteria.Query) ||
                    e.Department.Contains(criteria.Query) ||
                    e.Position.Contains(criteria.Query) ||
                    e.FullName.Contains(criteria.Query) ||
                    e.Email.Contains(criteria.Query))
            .Skip(criteria.Skip)
            .Take(criteria.Limit)
            .ToArray();

        return Task.FromResult(result);
    }
}
