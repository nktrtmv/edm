using Edm.Document.Classifier.Domain;

namespace Edm.Document.Classifier.ExternalServices.Employees.Contracts;

public sealed record EmployeeEx(
    string Id,
    string Login,
    string Department,
    string Position,
    string FullName,
    string Email,
    long? StaffId)
    : ITypedReference;
