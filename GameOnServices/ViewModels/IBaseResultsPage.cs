using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOnServices.ViewModels
{
    public interface IBaseResultsViewModel<T>
    {
        int Count { get;}

        IEnumerable<T> Items { get; }

        int Page { get; }

        int PageSize { get; }

        int Pages { get;  }

        int Total { get; }
    }
}
