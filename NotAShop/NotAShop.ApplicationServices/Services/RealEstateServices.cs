using NotAShop.Core.ServiceInterface;
using NotAShop.Data;


namespace NotAShop.ApplicationServices.Services
{
    public class RealEstateServices : IRealEstateServices
    {
        private readonly NotAShopContext _context;

        public RealEstateServices
            (
            NotAShopContext context
            )
        {
            _context = context;
        }
    }
}
