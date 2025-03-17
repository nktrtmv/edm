namespace Edm.Document.Classifier.ExternalServices.Employees.Contracts;

public sealed class EmployeeSearchCriteriaEx
{
    public EmployeeSearchCriteriaEx(string[] ids, string query, int skip, int limit)
    {
        Ids = ids;
        Query = query;
        Skip = skip;
        Limit = limit;
    }

    public string[] Ids { get; }
    public string Query { get; }
    public int Skip { get; }
    public int Limit { get; }
}
