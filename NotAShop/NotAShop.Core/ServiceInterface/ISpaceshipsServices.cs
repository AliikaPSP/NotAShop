
using NotAShop.Core.Domain;

namespace NotAShop.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> DetailAsync(Guid id);
    }
}
