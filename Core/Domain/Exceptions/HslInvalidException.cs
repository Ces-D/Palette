using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Exceptions
{
    public class HslInvalidException : Exception
    {
        public HslInvalidException(string hslString, Exception ex) : base($"Invalid Hsl string: {hslString}", ex)
        {

        }
    }
}
