using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GameOnServices.Models
{
    public class GameSearchCriteria
    {
        public GameSearchCriteria()
        {
            SortDirection = SortOrder.Ascending;
            SortField = "name";
            //PageSize = 10;
            //Page = 1;
            SearchText = "";
        }
        //[Description("filter=name:{0},deck:{1}")]
        public string SearchText { get; set; }
        public string FilterQuery { get; set; }
        
        //[Description("offset={0}")]
        public int PageSize { get; set; }

        public int Page { get; set; }

        //field list

        //format

        public string SortField { get; set; }

        public SortOrder SortDirection { get; set; }

    }
}