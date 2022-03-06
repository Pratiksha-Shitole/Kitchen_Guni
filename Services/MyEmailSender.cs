
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Kitchen_Guni.Services
{
    public class MyEmailSender
        : IEmailSender
    {
        private readonly IConfiguration _config;
        private readonly ILogger<MyEmailSender> _logger;

        public MyEmailSender(
            IConfiguration config,
            ILogger<MyEmailSender> logger)
        {
            _config = config;
            _logger = logger;
        }


        #region Microsoft.AspNetCore.Identity.UI.Services.IEmailSender members

        /// <summary>
        ///     Send the Email using the IEmailSender Service.
        /// </summary>
        /// <param name="email">From Email Address</param>
        /// <param name="subject">Subject of the Email</param>
        /// <param name="htmlMessage">HTML Text for the Email</param>
        /// <returns>Task to indicate if email was successfully sent.</returns>
        /// <exception cref="GuniApp.Web.Services.MyEmailSenderException" />
        /// <example>
        /// <![CDATA[
        ///     SendEmailAsync("demo@abc.com", "hello", "<p>Hello World</p>");
        ///     SendEmailAsync("demo@abc.com; a@abc.com", "hello", "<p>Hello World</p>");
        /// ]]>
        /// </example>
        public Task SendEmailAsync(
            string email, string subject, string htmlMessage)
        {
            var smtpServer = _config.GetValue<string>("MySmtpSettings:SmtpServer");
            var smtpServerSSL = _config.GetValue<bool>("MySmtpSettings:SmtpServerSSL");
            var smtpPort = _config.GetValue<int>("MySmtpSettings:SmtpPort");
            var smtpFromEmail = _config.GetValue<string>("MySmtpSettings:FromEmail");
            var smtpFromEmailAlias = _config.GetValue<string>("MySmtpSettings:FromEmailAlias");
            var smtpUsername = _config.GetValue<string>("MySmtpSettings:Username");
            var smtpPassword = _config.GetValue<string>("MySmtpSettings:Password");

            var client = new SmtpClient(smtpServer)
            {
                UseDefaultCredentials = false,
                EnableSsl = smtpServerSSL,
                Port = smtpPort,
                DeliveryMethod = SmtpDeliveryMethod.Network,

                Credentials = new NetworkCredential(
                    userName: smtpUsername,
                    password: smtpPassword)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpFromEmail, smtpFromEmailAlias),
                Subject = subject
            };
            // NOTE: Split multiple email addresses before adding to the collection
            mailMessage.To.Add(email);
            mailMessage.Priority = MailPriority.High;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = htmlMessage;

            MyEmailSenderException myexception;
            try
            {
                client.SendMailAsync(mailMessage).Wait();
                return Task.CompletedTask;
            }
            catch (SmtpFailedRecipientsException exp)
            {
                myexception = new MyEmailSenderException(
                    $"Unable to send email to {exp.FailedRecipient}", exp);
            }
            catch (SmtpFailedRecipientException exp)
            {
                myexception = new MyEmailSenderException(
                    $"Unable to send email to {exp.FailedRecipient}", exp);
            }
            catch (SmtpException exp)
            {
                myexception = new MyEmailSenderException(
                    $"There was problem sending email:{exp.Message}", exp);
            }
            catch (Exception exp)
            {
                myexception = new MyEmailSenderException(
                    $"Something went wrong! : {exp.Message}", exp);
            }

            return Task.FromException<MyEmailSenderException>(myexception);
        }

        #endregion
    }
}