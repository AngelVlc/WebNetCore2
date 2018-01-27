using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCore2.Exceptions
{
    public class WarningException : Exception
    {
        public WarningException() : base()
        {

        }

        public WarningException(string msg) : base(msg)
        {

        }

        public WarningException(string msg, Exception innerEx) : base(msg, innerEx)
        {

        }
    }
}
