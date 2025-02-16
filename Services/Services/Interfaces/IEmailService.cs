using Models;

namespace Services.Services.Interfaces
{
    public interface IEmailService
    {
        Task<string> EnviarEmailAsync(EnviarEmail modelEmail);
    }
}
