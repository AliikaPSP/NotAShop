using NotAShop.Core.Domain;

namespace NotAShop.Core.ServiceInterface
{
    public interface IKindergartensServices
    {
        Task<Kindergarten> DetailAsync(Guid id);
    }
}
