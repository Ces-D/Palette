using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Exceptions
{
    public class HexInvalidException : Exception
    {
        public HexInvalidException(string hexString, Exception ex) : base($"Invalid Hex string: {hexString}", ex)
        {

        }
    }
}
