using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCore2.Exceptions
{
    public class InfoException : Exception
    {
        public InfoException() : base()
        {

        }
         
        public InfoException(string msg) : base(msg)
        {

        }

        public InfoException(string msg, Exception innerEx) : base(msg, innerEx)
        {

        }
    }
}
