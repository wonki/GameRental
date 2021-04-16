using GameOnServices.Models;
using GameOnServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOnServices.Services
{
    public interface ISearchService
    {
        GamesViewModel SearchGames(GameSearchCriteria criteria);
    }
}
