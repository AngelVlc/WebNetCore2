using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCore2.Exceptions
{
    public class ErrorException : Exception
    {
        public ErrorException() : base()
        {

        }

        public ErrorException(string msg) : base(msg)
        {

        }

        public ErrorException(string msg, Exception innerEx) : base(msg, innerEx)
        {

        }
    }
}
