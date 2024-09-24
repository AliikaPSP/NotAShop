using Microsoft.EntityFrameworkCore;
using NotAShop.Core.Domain;
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
    }
}
