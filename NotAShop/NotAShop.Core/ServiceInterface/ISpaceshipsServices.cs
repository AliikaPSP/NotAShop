
using NotAShop.Core.Domain;
using NotAShop.Core.Dto;

namespace NotAShop.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> DetailAsync(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> Create(SpaceshipDto dto);
    }
}
