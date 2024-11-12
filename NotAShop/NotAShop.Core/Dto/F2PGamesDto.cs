using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace NotAShop.Core.Dto
{
    public class F2PGamesDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonPropertyName("short_description")]
        public string ShortDescription { get; set; }

        [JsonPropertyName("game_url")]
        public string GameUrl { get; set; }

        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("developer")]
        public string Developer { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("freetogame_profile_url")]
        public string FreetogameProfileUrl { get; set; }
    }
}
