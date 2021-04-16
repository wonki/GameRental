using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOnServices.ViewModels
{
    public class BaseResultsViewModel<T> : IBaseResultsViewModel<T>
    {
        public BaseResultsViewModel()
        {
            Items = new List<T>();
        }
      
        public void AddItems(IEnumerable<T> items, int page, int pageSize, int total)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            Total = total;
        }
        public int Count { get { return (Items == null) ? 0 : Items.Count(); } }

        public IEnumerable<T> Items { get; private set; }

        public int Page { get; private set; }

        public int PageSize { get; private set; }

        public int Pages { get { return (int)Math.Ceiling(Total / (double)PageSize); } }

        public int Total { get; private set; }
    }
}