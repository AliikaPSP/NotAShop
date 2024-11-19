using NotAShop.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAShop.Core.ServiceInterface
{
    public interface ICocktailsServices
    {
        Task<List<CocktailsDto>> GetCocktailsAsync(CocktailsDto dto);
    }
}
