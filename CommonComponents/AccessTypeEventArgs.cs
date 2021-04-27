using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public class AccessTypeEventArgs : IAccessTypeEventArgs
    {
        private AccessType _accessType;
        private bool _valuesWereChanged;
        public enum AccessType
        {
            Read,
            Add,
            Update,
            Delete
        }

        public bool ValuesWereChanged
        {
            get { return _valuesWereChanged; }
            set { _valuesWereChanged = value; }

        }

        public AccessType AccessTypeValue
        {
            get { return _accessType; }
            set { _accessType = value; }
        }
    }
}
