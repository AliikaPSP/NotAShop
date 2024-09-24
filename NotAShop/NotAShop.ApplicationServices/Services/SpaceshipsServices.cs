using Microsoft.EntityFrameworkCore;
using NotAShop.Core.Domain;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using NotAShop.Data;

namespace NotAShop.ApplicationServices.Services
{

    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly NotAShopContext _context;

        public SpaceshipsServices
            (
            NotAShopContext context
            )
        {
            _context = context;
        }

        public async Task<Spaceship> DetailAsync(Guid id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync( x => x.Id == id );

            return result;
        }

        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            Spaceship domain = new();

            domain.Id = dto.Id;
            domain.Name = dto.Name;
            domain.Type = dto.Type;
            domain.SpaceshipModel = dto.SpaceshipModel;
            domain.BuiltDate = dto.BuiltDate;
            domain.Crew = dto.Crew;
            domain.EnginePower = dto.EnginePower;
            domain.CreatedAt = dto.CreatedAt;
            domain.ModifiedAt = DateTime.Now;

            _context.Spaceships.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceship = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Spaceships.Remove(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }
    }
}
