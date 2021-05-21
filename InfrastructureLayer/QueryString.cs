using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class QueryString
    {
        private static string _query = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";

        public string GetQuery()
        {
            return _query;
        }
    }
}
