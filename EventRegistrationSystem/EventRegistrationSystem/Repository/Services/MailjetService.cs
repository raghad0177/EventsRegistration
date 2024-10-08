using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;

namespace EventRegistrationSystem.Repository.Services
{
    public class MailjetService
    {
        private readonly IConfiguration _configuration;
        private readonly MailjetClient _client;

        public MailjetService(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new MailjetClient(
                _configuration["Mailjet:ApiKey"],
                _configuration["Mailjet:SecretKey"]);
        }

        public async Task<bool> SendEmailAsync(string toEmail, string toName,  string htmlPart)
        {
            var request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "abdullahraghad616@gmail.com")
            .Property(Send.FromName, "Events Manager")
            .Property(Send.Subject, "Email Approved")
            .Property(Send.TextPart, "You Email Have Been Approved")
            .Property(Send.HtmlPart, htmlPart)
            .Property(Send.Recipients, new JArray {
            new JObject {
                {"Email", toEmail},
                {"Name", toName}
            }
            });


            MailjetResponse response = await _client.PostAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
}
