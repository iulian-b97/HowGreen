using Library.Server.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public ContactController()
        {

        }

        [HttpPost]
        [Route("SendMessage")]
        public async Task<ActionResult> SendMessage(MessageModel model, string userName)
        {
            MessageModel messageModel = new MessageModel
            {
                ReceiverEmail = model.ReceiverEmail,
                Content = model.Content
            };
            messageModel.UserName = userName;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Utilizatorul HowGreen: " + messageModel.UserName, "system.howgreen@gmail.com"));
            message.To.Add(new MailboxAddress("naren", messageModel.ReceiverEmail));
            message.Subject = "Mesaj trimis de un utilizator HowGreen";
            message.Body = new TextPart("plain")
            {
                Text = messageModel.Content
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("system.howgreen@gmail.com", "golfgti456");

                client.Send(message);

                client.Disconnect(true);
            }

            return Ok();
        }
    }
}
