using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOnServices.ProxyServices
{
    public interface IApiHelper
    {
        dynamic GetData(Type responseType, string apiPath, string queryParams);
    }
}
