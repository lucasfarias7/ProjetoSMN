using SMNPastel.Mapper;

namespace SMNPastel.Configuration
{
    public static class ConfigurationMapper
    {
        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
