using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOnServices.Models
{
    public class ImageResponseModel
    {
        public string Icon_url { get; set; }
        public string Medium_url { get; set; }
        public string Screen_url { get; set; }
        public string Screen_large_url { get; set; }
        public string Small_url { get; set; }
        public string Super_url { get; set; }
        public string Thumb_url { get; set; }
        public string Tiny_url { get; set; }
        public string Original_url { get; set; }
        public string Image_tags { get; set; }
    }
}