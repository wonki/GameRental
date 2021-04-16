using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOnServices.Models
{
    public class BaseApiResponse
    {
        public string Error { get; set; }
        public int Limit { get; set; }
        public string Status_code { get; set; }
        public int Number_of_total_results { get; set; }
        public int Number_of_page_results { get; set; }
        public int Offset { get; set; }
        public string Version { get; set; }

    }
}