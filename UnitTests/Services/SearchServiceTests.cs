using System;
using System.Collections.Generic;
using System.Linq;
using GameOnServices.Models;
using GameOnServices.ProxyServices;
using GameOnServices.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Services
{
    [TestClass]
    public class SearchServiceTests
    {
        private Mock<IApiHelper> _mockApiHelper;
        private ISearchService _searchService;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockApiHelper = new Mock<IApiHelper>();
            _searchService = new SearchService(_mockApiHelper.Object);
        }

        [TestMethod]
        public void TestSearchGames()
        {
            //arrange
            
            var games = GetDummyGames();
            _mockApiHelper.Setup(s => s.GetData(typeof(GiantBombGameSearchResponse),It.IsAny<string>(), It.IsAny<string>())).Returns(games);

            //act
            var result = _searchService.SearchGames(new GameSearchCriteria() { SearchText = "call" });

            //assert
            _mockApiHelper.VerifyAll();
            Assert.AreEqual(1, result.Items.Count());
            Assert.IsTrue(result.Items.First().Name.Contains("Call"));
        }


        private GiantBombGameSearchResponse GetDummyGames()
        {
            var gameList = new List<GamesResponseFields>() {

                new GamesResponseFields(){
                Id = 22,
                Guid = "3030-556",
                Deck = "Call of Duty Balck Ops",
                Image = new ImageResponseModel{ Thumb_url= "http://somepicURL.com/images/1233.jpg" },
                 Original_release_date = "04-01-2019",
                Name = "Call of Duty",                
                }};

            GiantBombGameSearchResponse games = new GiantBombGameSearchResponse();
            games.Results = gameList;
            return games;
        }
    }
}
