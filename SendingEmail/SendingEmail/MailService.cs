using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendingEmail
{
  public class MailService: IMailService
  {
    private readonly ILogger<MailService> logger;
    public MailService(ILogger<MailService> logger)
    {
      this.logger = logger;
    }
    public void SendEmailCustom()
    {
      try
      {
        MimeMessage message = new MimeMessage();
        message.From.Add(new MailboxAddress("название", "asd@asd.ru"));
        message.To.Add(new MailboxAddress("кудаотправить@gmail.com"));
        message.Subject = "Сообщение от MailKit";
        message.Body = new BodyBuilder() { HtmlBody = "<div style=\"color: green;\">Сообщение от MailKit</div>" }.ToMessageBody();

        using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
        {
          client.Connect("smtp.gmail.com", 465, true);
          client.Authenticate("твояпочта@gmail.com", "secret");
          client.Send(message);

          client.Disconnect(true);
          logger.LogInformation("Сообщение отправлено успешно");
        }

      }
      catch(Exception e)
      {
        logger.LogError(e.GetBaseException().Message);
      }
    }
  }
}
