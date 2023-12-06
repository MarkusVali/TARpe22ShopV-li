using Microsoft.AspNetCore.Mvc;
using ValiShop.Core.Dto;
using ValiShop.Core.ServiceInterface;
using ValiShop.Models.Email;

namespace ValiShop.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(EmailViewModel vm)
        {
            var dto = new EmailDto()
            {
                To = vm.To,
                Subject = vm.Subject,
                Body = vm.Body,
            };

            _emailService.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
