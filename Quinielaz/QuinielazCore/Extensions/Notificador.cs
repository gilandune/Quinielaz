﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Extensions
{
    public class Notificador
    {
        /// <summary>
        /// Permite enviar un correo electrónico desde la cuenta de correo configurada en la aplicación
        /// </summary>
        /// <param name="Destinatario">Pueden ser varios separados por ','</param>
        /// <param name="Asunto">Corresponde al subject del correo</param>
        /// <param name="Mensaje">Este puede ser en formato html para darle edición</param>
        /// <returns></returns>
        public static bool SendMail(string Destinatario, string Asunto, string Mensaje)
        {
            bool Enviado = false;
            try
            {
                string MailParameters = ConfigurationManager.AppSettings["CorreoString"].ToString();
                SmtpClient client = new SmtpClient();
                client.Port = Convert.ToInt32(MailParameters.Split(',')[3]);
                client.Host = MailParameters.Split(',')[2];
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(MailParameters.Split(',')[0], MailParameters.Split(',')[1]);
                MailAddress From = new MailAddress("noreply@fujifilm.mx");
                MailMessage message = new MailMessage();
                message.From = From;
                message.Sender = new MailAddress("noreply@fujifilm.mx", "No Reply");
                message.ReplyToList.Add(new MailAddress("noreply@fujifilm.mx", "No Reply"));
                string[] Destinatarios = Destinatario.Split(',');
                foreach (string destinatario in Destinatarios)
                    message.To.Add(new MailAddress(destinatario.Trim()));
                message.Subject = Asunto;
                string FilePath = string.Empty;
                List<string> ConjuntoCertificados = new List<string>();
                message.Body = Mensaje;
                message.IsBodyHtml = true;
                client.Send(message);
                Enviado = true;
            }
            catch (Exception exc)
            {
                Log.EscribeLog("Error al intentar enviar el correo con asunto: " + Asunto + ": " + exc.Message);
            }
            return Enviado;
        }
    }
}