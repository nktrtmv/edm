using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Classifier.ExternalServices.Categories;

public static class CategoryClientRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<ICategoryClient, CategoryClient>();
    }
}
