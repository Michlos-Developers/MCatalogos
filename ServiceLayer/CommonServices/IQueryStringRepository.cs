using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CommonServices
{
    public interface IQueryStringRepository
    {
        string GetQuery();

        string GetQueryApp();

        string GetQueryAccessApp();

    }
}
