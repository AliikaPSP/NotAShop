using Microsoft.AspNetCore.Mvc;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using NotAShop.Models.Emails;

namespace NotAShop.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailsServices _emailServices;
        public EmailsController(IEmailsServices emailServices)
        {
            _emailServices = emailServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        //nüüd tuleb meetod teha
        [HttpPost]
        public IActionResult SendEmail(EmailViewModel vm)
            {
                var dto = new EmailDto()
                {
                    To = vm.To,
                    Subject = vm.Subject,
                    Body = vm.Body,
                };
                _emailServices.SendEmail(dto);

                return RedirectToAction(nameof(Index));
            }
    }
}
