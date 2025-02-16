using Microsoft.EntityFrameworkCore;
using SMNPastel.Data;

namespace SMNPastel.Configuration
{
    public static class ConfigurationDB
    {
        public static void GetSettingsDb(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SMNContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
