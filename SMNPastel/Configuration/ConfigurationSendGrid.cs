using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SMNPastel.Configuration
{
    public static class ConfigurationSendGrid
    {
        public static string ConfigureSendGrid(this WebApplicationBuilder builder)
        {
            return builder.Configuration["SendGrid:ApiKey"];
        }
    }
}
