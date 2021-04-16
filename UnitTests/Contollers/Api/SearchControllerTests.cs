using System;
using System.Collections.Generic;
using System.Linq;
using GameOnServices.Controllers.Api;
using GameOnServices.Models;
using GameOnServices.Services;
using GameOnServices.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Contollers.Api
{
    [TestClass]
    public class SearchControllerTests
    {
        private Mock<ISearchService> _mockSerchService;
        private SearchController _searchController;

        [TestInitialize]
        public void TestInitialize() {
            _mockSerchService = new Mock<ISearchService>();
            _searchController = new SearchController(_mockSerchService.Object);
        }

        [TestMethod]
        public void TestSearchGames()
        {
            //arrange
            
            var games = GetDummyGames();                                 
            _mockSerchService.Setup(s => s.SearchGames(It.IsAny<GameSearchCriteria>())).Returns(games);

            //act
            var result = _searchController.SearchGames(new GameSearchCriteria() { SearchText = "call" });

            //assert
            _mockSerchService.VerifyAll();
            Assert.AreEqual(1, result.Items.Count());
            Assert.IsTrue(result.Items.First().Name.Contains("Call"));
        }
                

        private GamesViewModel GetDummyGames() {
            var gameList = new List<GameViewModel>() {

                new GameViewModel(){
                Id = 22,
                Guid = "3030-556",
                Summary = "Call of Duty Balck Ops",
                ImageUrl = "http://somepicURL.com/images/1233.jpg",
                ReleasedDate = DateTime.Now.AddDays(-100),
                Name = "Call of Duty",
                Rent = 1.99M,
                }};

            GamesViewModel games = new GamesViewModel();
            games.AddItems(gameList, 1, 1, 100);
            return games;
        }
    }
}
