using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCore2.Models
{
    public class ApiResult
    {
        // 1 = info, 2 = warning, 3 = error, 0 = excepción servidor
        public int? Severity { get; set; }

        public object Data { get; set; }        

        public string Message { get; set; }
    }
}
