using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAShop.Core.Dto
{
    public class ChuckNorrisDto
    {
        public List<string> Categories { get; set; }
        public DateTime CreatedAt { get; set; }
        public string IconUrl { get; set; }
        public string Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
    }
}
