using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI.Exceptions
{
    public class GoneException : Exception
    {
        public GoneException()
        {
        }

        public GoneException(string message) : base(message)
        {
        }

    }
}
