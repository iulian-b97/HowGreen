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
        public async Task<ActionResult> SendMessage()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test Project", "iulian.burghelea1998@gmail.com"));
            message.To.Add(new MailboxAddress("naren", "iulian.burghelea1997@gmail.com"));
            message.Subject = "test mail in asp.net core";
            message.Body = new TextPart("plain")
            {
                Text = "hello world mail"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("iulian.burghelea1998@gmail.com", "golfgti456");

                client.Send(message);

                client.Disconnect(true);
            }

            return Ok(message);
        }
    }
}
