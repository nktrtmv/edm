using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Classifier.ExternalServices.Contractors;

public static class ContractorsClientRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<IContractorsClient, ContractorsClient>();
    }
}
