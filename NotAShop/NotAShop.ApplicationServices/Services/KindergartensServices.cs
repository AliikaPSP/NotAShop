using Microsoft.EntityFrameworkCore;
using NotAShop.Core.Domain;
using NotAShop.Core.ServiceInterface;
using NotAShop.Data;

namespace NotAShop.ApplicationServices.Services
{
    public class KindergartensServices : IKindergartensServices
    {
        private readonly NotAShopContext _context;

        public KindergartensServices
            (
                NotAShopContext context
            )
        {
            _context = context;
        }

        public async Task<Kindergarten> DetailAsync(Guid id)
        {
            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
