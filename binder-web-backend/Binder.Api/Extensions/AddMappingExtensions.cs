using Binder.Api.Mappings;
using Binder.Persistence.Mappings;

namespace Binder.Api.Extensions
{
    public static class AddMappingExtensions
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PDtoToCoreModelsMappingsProfile), typeof(DtoToCoreModelsMappingsProfile));

            return services;
        }
    }
}