using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Classifier.ExternalServices.Employees;

public static class EmployeesClientRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<IEmployeesClient, EmployeesClient>();
    }
}
