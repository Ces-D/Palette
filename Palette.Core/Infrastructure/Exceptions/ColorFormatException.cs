using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure.Exceptions
{
    public class ColorFormatException : Exception
    {
        public ColorFormatException(string colorModel, string value) : base($"Your {colorModel} input string is incorrectly entered: {value}")
        {

        }
    }
}
