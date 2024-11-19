using NotAShop.Core.Dto;

namespace NotAShop.Models.Cocktails
{
    public class CocktailsIndexViewModel
    {
        public string SearchTerm { get; set; }
        public List<CocktailsDto> Cocktails { get; set; } = new List<CocktailsDto>();
    }
}
