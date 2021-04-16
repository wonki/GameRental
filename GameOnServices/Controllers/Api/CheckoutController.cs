using GameOnServices.Models;
using GameOnServices.Services;
using GameOnServices.ViewModels;
using System;
using System.Web.Http;

namespace GameOnServices.Controllers.Api
{
    public class CheckoutController : ApiController
    {
        private ISearchService _searchService;
        public CheckoutController(ISearchService searchService)
        {
            _searchService = searchService;

        }


        [HttpGet]
        [Route("api/Checkout/GetCartDetails")]
        public GamesViewModel GetCartDetails()
        {
            GamesViewModel cartDetails = new GamesViewModel();
            var session = System.Web.HttpContext.Current.Session;
            if (session != null && session["Cart"] != null)
            {
                var cart = (CartViewModel)session["Cart"];
                var criteria = new GameSearchCriteria() { SortField = "name" };
                var gameIds = string.Join("|", cart.GameIds);
                criteria.FilterQuery = "&filter=id:" + gameIds;

                cartDetails = _searchService.SearchGames(criteria);                
            }
            return cartDetails;
        }

        [HttpPost]
        [Route("api/Checkout/MakeAPayment")]
        public void MakeAPayment()
        {
            var session = System.Web.HttpContext.Current.Session;
            if (session != null)
            {
                session["Cart"] = null;
            }
            
        }

        [HttpGet]
        [Route("api/Checkout/Remove/{gameId}")]
        public GamesViewModel Remove(int gameId)
        {
            var session = System.Web.HttpContext.Current.Session;
            if (session != null && session["Cart"] != null)
            {
                var cart = (CartViewModel)session["Cart"];
                cart.GameIds.Remove(gameId);

                session["Cart"] = cart;

                return GetCartDetails();
            }
            else
            {
                throw new Exception("Nothing to remove");
            }
        }
    }
}