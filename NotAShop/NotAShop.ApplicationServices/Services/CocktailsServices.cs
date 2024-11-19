using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotAShop.ApplicationServices.Services
{
    public class CocktailsServices : ICocktailsServices
    {
        private const string BaseUrl = "https://www.thecocktaildb.com/api/json/v1/1";

        public async Task<List<CocktailsDto>> GetCocktailsAsync(CocktailsDto dto)
        {
            if (string.IsNullOrEmpty(dto?.strDrink))
            {
                throw new ArgumentException("Drink name cannot be null or empty.", nameof(dto.strDrink));
            }

            string url = $"{BaseUrl}/search.php?s={Uri.EscapeDataString(dto.strDrink)}";

            List<CocktailsDto> cocktailsList = new List<CocktailsDto>();

            using (WebClient client = new WebClient())
            {
                try
                {
                    string json = await Task.Run(() => client.DownloadString(url));
                    var root = JsonSerializer.Deserialize<CocktailsApiResponse>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (root?.Drinks != null)
                    {
                        cocktailsList.AddRange(root.Drinks);
                    }
                }
                catch (WebException ex)
                {
                    Console.WriteLine($"Network error: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"JSON error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }

            return cocktailsList;
        }
    }

    public class CocktailsApiResponse
    {
        public List<CocktailsDto> Drinks { get; set; }
    }
}
