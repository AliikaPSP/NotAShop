using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NotAShop.Core.Domain;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using NotAShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAShop.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly NotAShopContext _context;
        public FileServices
            (
                IHostEnvironment webHost,
                NotAShopContext context
            )
        {
            _webHost = webHost;
            _context = context;
        }
        public void FilesToApi(SpaceshipDto dto, Spaceship spaceship)
        {
            if(!Directory.Exists(_webHost.ContentRootPath + "\\multipleFileUpload\\"))
            {
                Directory.CreateDirectory(_webHost.ContentRootPath + "\\multipleFileUpload\\");
            }

            foreach(var file in dto.Files)
            {
                string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "multipleFileUpload");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    FileToApi path = new FileToApi
                    {
                        Id = Guid.NewGuid(),
                        ExistingFilePath = uniqueFileName,
                        SpaceshipId = spaceship.Id
                    };

                    _context.FileToApis.AddAsync(path);
                }
            }
        }
    }
}
