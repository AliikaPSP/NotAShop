using NotAShop.Core.Domain;
using NotAShop.Core.Dto;

namespace NotAShop.Core.ServiceInterface
{
    public interface IRealEstateServices
    {
        Task<RealEstate> Create(RealEstateDto dto);
        Task<RealEstate> GetAsync(Guid id);
    }
}
