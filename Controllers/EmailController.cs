using EFCoreRelationships.DTOs;
using EFCoreRelationships.EmailService;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(RequestDTO request)
        {
            var result = emailService.SendEmail(request); 
           
            return Ok(result);

        }
    }

   
}
