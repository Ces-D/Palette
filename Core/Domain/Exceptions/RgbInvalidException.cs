using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Exceptions
{
    public class RgbInvalidException : Exception
    {
        public RgbInvalidException(string rgbString, Exception ex) : base($"Invalid Rgb string: {rgbString}", ex) { }
        public RgbInvalidException(string rgbString) : base($"Invalid Rgb string: {rgbString}") { }
    }
}
