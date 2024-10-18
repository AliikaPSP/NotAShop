using Microsoft.EntityFrameworkCore;
using NotAShop.Core.Domain;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using NotAShop.Data;
using System.Xml;

namespace NotAShop.ApplicationServices.Services
{
    public class KindergartensServices : IKindergartensServices
    {
        private readonly NotAShopContext _context;
        private readonly IFileServices _fileServices;

        public KindergartensServices
            (
                NotAShopContext context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<Kindergarten> DetailAsync(Guid id)
        {
            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            Kindergarten domain = new();

            domain.Id = dto.Id;
            domain.GroupName = dto.GroupName;
            domain.ChildrenCount = dto.ChildrenCount;
            domain.KindergartenName = dto.KindergartenName;
            domain.Teacher = dto.Teacher;
            domain.CreatedAt = dto.CreatedAt;
            domain.UpdatedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _fileServices.UploadImagesToDatabase(dto, domain);
            }

            _context.Kindergartens.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Kindergarten> Delete(Guid id)
        {
            var kindergarten = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.ImageToDatabases
                .Where(x => x.KindergartenId == id)
                .Select(y => new ImageToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    KindergartenId = y.KindergartenId,
                }).ToArrayAsync();


            await _fileServices.RemoveKindergartenImagesFromDatabase(images);
            _context.Kindergartens.Remove(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        public async Task<Kindergarten> Create(KindergartenDto dto)
        {
            Kindergarten kindergarten = new Kindergarten();

            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.Teacher = dto.Teacher;
            kindergarten.CreatedAt = DateTime.Now;
            kindergarten.UpdatedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _fileServices.UploadImagesToDatabase(dto, kindergarten);
            }

            await _context.Kindergartens.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }


        public async Task<Kindergarten> DetailsAsync(Guid id)
        {
            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }



    }
}
