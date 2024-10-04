using NotAShop.Core.Domain;
using NotAShop.Core.Dto;

namespace NotAShop.Core.ServiceInterface
{
    public interface IKindergartensServices
    {
        Task<Kindergarten> DetailAsync(Guid id);
        Task<Kindergarten> Update(KindergartenDto dto);
    }
}
