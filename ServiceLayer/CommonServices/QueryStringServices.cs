namespace ServiceLayer.CommonServices
{
    public class QueryStringServices : IQueryStringRepository
    {
        private IQueryStringRepository _queryStringRepository;

        public QueryStringServices(IQueryStringRepository queryStringRepository)
        {
            _queryStringRepository = queryStringRepository;
        }

        public string GetQuery()
        {
            return _queryStringRepository.GetQuery();
        }

        public string GetQueryAccessApp()
        {
            return _queryStringRepository.GetQueryAccessApp();
        }

        public string GetQueryApp()
        {
            return _queryStringRepository.GetQueryApp();
        }
    }
}
