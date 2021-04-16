using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOnServices.Models
{
    public class GiantBombGameSearchResponse:BaseApiResponse
    {
        public GiantBombGameSearchResponse()
        {
            Results = new List<GamesResponseFields>();
        }
        public List<GamesResponseFields> Results { get; set; }
        

    }
}