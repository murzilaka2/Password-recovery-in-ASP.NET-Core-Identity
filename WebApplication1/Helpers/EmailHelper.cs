using MailKit.Net.Smtp;
using MimeKit;

namespace WebApplication1.Helpers
{
    public class EmailHelper
    {
        public bool SendEmailPasswordReset(string userEmail, string link)
        {
            var message = new MimeMessage();
            //от кого отправляем и заголовок
            message.From.Add(new MailboxAddress("WebApplication1 Project", "enykoruna1@gmail.com"));
            //кому отправляем
            message.To.Add(new MailboxAddress("Имя Человека", userEmail));
            //тема письма
            message.Subject = "Сброс пароля на сайте WebApplication1";
            //тело письма
            message.Body = new TextPart("html")
            {
                Text = link,
            };
            using (var client = new SmtpClient())
            {
                //Указываем smtp сервер почты и порт
                client.Connect("smtp.gmail.com", 587, false);
                //Указываем свой Email адрес и пароль приложения
                client.Authenticate("enykoruna1@gmail.com", "vyukyhxivmwudrap");

                try
                {
                    client.Send(message);
                    return true;
                }
                catch (Exception)
                {

                    //Logging information
                }
                finally
                {
                    client.Disconnect(true);
                }                            
            }
            return false;
        }
    }
}
