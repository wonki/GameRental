using GameOnServices.Models;
using GameOnServices.Services;
using GameOnServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace GameOnServices.Controllers.Api
{
    public class SearchController : ApiController
    {
        private ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
                      

        // POST api/<controller>
        [HttpPost]
        [Route("api/Search/SearchGames")]
        public GamesViewModel SearchGames(GameSearchCriteria criteria)
        {
            //GameSearchCriteria criteria = new GameSearchCriteria();
            if (string.IsNullOrEmpty(criteria.SortField))
                criteria.SortField = "name";
            if (criteria.PageSize <= 0)
                criteria.PageSize = 10;
            if (criteria.Page <= 0)
                criteria.Page = 1;

            criteria.FilterQuery = string.Format("&filter=name:{0}",criteria.SearchText);
            var result = _searchService.SearchGames(criteria);
                        
            return result;            
        }


        [HttpPost]
        [Route("api/Search/SaveToCart")]
        public CartViewModel SaveToCart(CartViewModel cart)
        {
            //save data to session for the time being as no DB is implemented
            //this is kind of an anti pattern as this would make the API statefull in a way
            var session = System.Web.HttpContext.Current.Session;
            if (session != null)
            {                
                session["Cart"] = cart;                                
            }            
            return GetCart();
        }

        [HttpGet]
        [Route("api/Search/GetCart")]
        public CartViewModel GetCart()
        {
            CartViewModel result = new CartViewModel();
            var session = System.Web.HttpContext.Current.Session;
            if (session != null && session["Cart"] != null)
            {
                result = (CartViewModel)session["Cart"];
            }           
            return result;
        }
       
    }
}