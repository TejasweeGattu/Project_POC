using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer
{
    [Serializable]
    public class ApiException:Exception
    {
        public ApiException() { }   

        public ApiException(string message) : base(message){ 

        }
        public ApiException(string message, Exception inner)
       : base(message, inner)
        {
        }

    }
}
