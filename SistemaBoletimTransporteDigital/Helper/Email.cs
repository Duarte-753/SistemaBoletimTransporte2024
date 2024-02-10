
using SistemaBoletimTransporteDigital.Models;
using System.Net;
using System.Net.Mail;


namespace SistemaBoletimTransporteDigital.Helper
{
    
    public class Email : IEmail
    {       


       
        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                
                string host = "smtp-mail.outlook.com";
                string nome = "Sistema Boletim de Transportes";
                string username = "sistemasbtd1234@hotmail.com";
                string senha = "1234sistemasbtd";
                int porta = 587;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, nome)
                };

                mail.To.Add(email);
                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                //teste 
                //mail.SubjectEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                //mail.BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8");

                using (SmtpClient smtp = new SmtpClient(host, porta))
                {
                    smtp.Credentials = new NetworkCredential(username, senha);
                    smtp.EnableSsl = true;

                    smtp.Send(mail);//enviar
                    
                    return true;
                }

            }
            catch (Exception ex)
            {
                // Gravar log de erro ao enviar email
                return false;
            }
        }
    }
}
