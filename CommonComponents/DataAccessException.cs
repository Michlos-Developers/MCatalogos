using System;

namespace CommonComponents
{
    public class DataAccessException : Exception
    {
        public DataAccessException()
        {
        }

        public DataAccessStatus _dataAccessStatus { get; set; }

        public DataAccessStatus DataAccessStatusInfo
        {
            get { return _dataAccessStatus; }
            set { _dataAccessStatus = value; }
        }

        public DataAccessException(DataAccessStatus dataAccessStatus)
        {
            _dataAccessStatus = dataAccessStatus;
        }

        public DataAccessException(string message, Exception innerException, DataAccessStatus dataAccessStatus) : base(message, innerException)
        {
            _dataAccessStatus = dataAccessStatus;
        }
    }
}
