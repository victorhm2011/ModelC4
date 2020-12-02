using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Aplication.REST_Layer.Exceptions
{
    public class BadRequestException:Exception
    {
        public BadRequestException(string ex) : base(ex)
        {

        }
    }
}
