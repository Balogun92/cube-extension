using CubeExtension.Core.DTOs;
using CubeExtension.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CubeExtension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IEmailService _service; 
        public ContactController(IEmailService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContactDTO req)
        {
            try
            {
                var eConfig = new EmailSendConfigure();
                var content = new EmailContent();

                eConfig.TOs = req.Email;
                eConfig.Subject = req.Subject;
                eConfig.From = "Info@cubxtension.com";
                eConfig.FromDisplayName = "Cube Extension";
                eConfig.ClientCredentialUserName = "Info@cubxtension.com";
                eConfig.ClientCredentialPassword = "@Olatunbi82";
                eConfig.Priority = System.Net.Mail.MailPriority.Normal;
                eConfig.CCs = new string[] { };


                content.Content = req.Message;
                _service.SendMail(eConfig, content);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message ?? ex.InnerException?.Message);
            }
        }
    }
}
