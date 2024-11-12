using NotAShop.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAShop.Core.ServiceInterface
{
    public interface IF2PGamesServices
    {
        Task<List<F2PGamesDto>> GetF2PGamesAsync(F2PGamesDto dto);
    }
}
