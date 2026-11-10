using RagSample.Core.Interfaces;
using RagSample.Core.Services;
using RagSample.Infrastructure.ApiClients;

namespace RagSample.Api.Extensions
{
    public static class AddDependecies
    { 
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILlmApiClient, OpenRouterApiClient>();
            services.AddScoped<IVectorDbApiClient, PineconeApiClient>();
            services.AddScoped<IDocumentService, DocumentService>();

            return services;
        }
    }
}
