using Microsoft.AspNetCore.Mvc;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using NotAShop.Models.Emails;
using System.IO;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", vm);
            }

            var attachmentPaths = new List<string>();

            if (vm.Attachments != null && vm.Attachments.Count > 0)
            {
                foreach (var file in vm.Attachments)
                {
                    if (file.Length > 0)
                    {
                        var filePath = Path.Combine(Path.GetTempPath(), file.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        attachmentPaths.Add(filePath);
                    }
                }
            }

            var dto = new EmailDto
            {
                To = vm.To,
                Subject = vm.Subject,
                Body = vm.Body,
                Attachments = attachmentPaths
            };

            _emailServices.SendEmail(dto);

            // Clean up temporary files
            foreach (var path in attachmentPaths)
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
