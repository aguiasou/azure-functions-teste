using System;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;

namespace FunctionAzureSendEmail
{
    public static class FunctionSendEmail
    {
        [FunctionName("sendEmailTesteHelaine")]
        public static void Run([TimerTrigger("10 * * * * *")]TimerInfo myTimer,
       [SendGrid(ApiKey = "CustomSendGridKeyAppSettingName")] out SendGridMessage message)
        {
            var emailObject = new OutgoingEmail();
            emailObject.Body = "Teste de envio de email no Azure Functions com sendgrid";

            message = new SendGridMessage();
            message.AddTo("helaine.jesus@itixti.com.br");
            message.AddContent("text/html", emailObject.Body);
            message.SetFrom(new EmailAddress("helaine.jesus@hotmail.com"));
            message.SetSubject("Teste Azure Functions");
        }

        public class OutgoingEmail
        {
            public string To { get; set; }
            public string From { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
        }
    }
}
