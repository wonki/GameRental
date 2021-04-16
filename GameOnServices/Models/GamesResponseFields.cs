using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOnServices.Models
{
    public class GamesResponseFields
    {
        public GamesResponseFields()
        {
            Image = new ImageResponseModel();
        }
        public int Id { get; set; }
        public string Deck { get; set; }
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Original_release_date { get; set; }
        public ImageResponseModel Image { get; set; }
    }
}