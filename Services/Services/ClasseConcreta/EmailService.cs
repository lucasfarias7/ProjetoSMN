using Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using Services.Services.Interfaces;

namespace Services.Services.ClasseConcreta
{
    public class EmailService : IEmailService
    {
        private readonly string _sendGridApyKey;

        public EmailService(string sendGridApyKey)
        {
            _sendGridApyKey = sendGridApyKey;
        }

        public async Task<string> EnviarEmailAsync(EnviarEmail modelEmail)
        {
            var client = new SendGridClient(_sendGridApyKey);
            var from = new EmailAddress("lucasfarias14@outlook.com", "Lucas Farias");
            var to = new EmailAddress(modelEmail.Destinatario);
            var msg = MailHelper.CreateSingleEmail(from, to, modelEmail.Assunto, modelEmail.Mensagem, modelEmail.Mensagem);
            var response = await client.SendEmailAsync(msg);

            if(response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                return "E-mail enviado com sucesso!";
            }
            else
            {
                return $"Erro ao enviar e-mail: {response.StatusCode}";
            }
        }
    }
}
