using System.Text.Json.Serialization;

namespace NotAShop.Models.F2PGames
{
    public class F2PGamesIndexViewModel
    {
        public string SearchTerm { get; set; }
        public List<F2PGamesIndexViewModel> Games { get; internal set; }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Thumbnail { get; set; }

        public string ShortDescription { get; set; }

        public string GameUrl { get; set; }

        public string Genre { get; set; }

        public string Platform { get; set; }

        public string Publisher { get; set; }

        public string Developer { get; set; }

        public string ReleaseDate { get; set; }

        public string FreetogameProfileUrl { get; set; }
        
    }
}
