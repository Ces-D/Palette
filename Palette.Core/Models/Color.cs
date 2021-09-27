using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.Models
{
    public class Color : IColor
    {
        public string Role { get; set; }
        public string Value { get; set; }
        public Boolean Locked { get; set; } = false;
    }
}
