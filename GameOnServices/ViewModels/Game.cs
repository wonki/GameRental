using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOnServices.ViewModels
{
    [Serializable]
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genres { get; set; }
        public string ImageUrl { get; set; }

        public int NumberOfUserReviews { get; set; }
        public string Guid { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime ReleasedDate { get; set; }
        public string GameRatingUrl { get; set; }
        public string GameDetailUrl { get; set; }
        public decimal Rent { get; set; }

    }
}