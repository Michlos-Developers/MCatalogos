using ServiceLayer.CommonServices;

namespace InfrastructureLayer
{
    public class QueryString : IQueryStringRepository
    {
        private static string _query = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";
        private static string _queryApp = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";
        private static string _queryAccessApp = @"SERVER=.\SQLEXPRESS;DATABASE=MCatalogoDB;INTEGRATED SECURITY=SSPI";

        public string GetQuery()
        {
            return _query;
        }

        public string GetQueryApp()
        {
            return _queryApp;
        }
        
        public string GetQueryAccessApp()
        {
            return _queryAccessApp;
        }
    }
}
