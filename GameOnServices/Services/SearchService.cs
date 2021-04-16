using GameOnServices.Models;
using GameOnServices.ProxyServices;
using GameOnServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GameOnServices.Services
{
    public class SearchService : ISearchService
    {
        private readonly IApiHelper _apiHelper;
        private readonly decimal _gameRent = 1.99M;
        public SearchService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public GamesViewModel SearchGames(GameSearchCriteria criteria)
        {
            string endpoint = "api/games/";

            //build query params
            StringBuilder sb = new StringBuilder("&format=json");
            sb.Append("&sort=");
            sb.Append(criteria.SortField);
            sb.Append(":");
            sb.Append(criteria.SortDirection==SortOrder.Ascending?"asc":"desc");
            if (criteria.PageSize > 0)
            {
                sb.Append("&limit=");
                sb.Append(criteria.PageSize);
            }
            if (criteria.Page > 0)
            {
                sb.Append("&offset=");
                sb.Append((criteria.Page - 1) * criteria.PageSize);
            }
            //filter
            if (!string.IsNullOrEmpty(criteria.SearchText) && string.IsNullOrEmpty(criteria.FilterQuery))
            {
                sb.Append("&filter=name:");
                sb.Append(criteria.SearchText);
            }
            else if (!string.IsNullOrEmpty(criteria.FilterQuery))
            {
                sb.Append(criteria.FilterQuery);

            }
            
            //return field list
            sb.Append("&field_list=id,name,deck,guid,image,original_release_date");
                        
            //call API
            GiantBombGameSearchResponse responseData = _apiHelper.GetData(typeof(GiantBombGameSearchResponse), endpoint, sb.ToString());


            //convert GiantBombGameSearchResponse to Games
            var gameList = new List<GameViewModel>();
            foreach (var item in responseData.Results)
            {
                GameViewModel newGame = new GameViewModel();
                newGame.Id = item.Id;
                newGame.Guid = item.Guid;
                newGame.Summary = item.Deck;
                newGame.ImageUrl = item.Image.Thumb_url;
                newGame.ReleasedDate = Convert.ToDateTime(item.Original_release_date);
                newGame.Name = item.Name;
                newGame.Rent = _gameRent;
                gameList.Add(newGame);
            }

            GamesViewModel games = new GamesViewModel();
            games.AddItems(gameList, criteria.Page, gameList.Count, responseData.Number_of_total_results);

            return games;
        }
    }
}