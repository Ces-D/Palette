using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Exceptions
{
    class HsvInvalidException : Exception
    {
        public HsvInvalidException(string hsvString, Exception ex) : base($"Invalid Hsv string: {hsvString}", ex)
        {

        }
    }
}
