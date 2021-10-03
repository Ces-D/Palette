using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.Interfaces
{
    public interface IColor
    {
        public string Role { get; set; }
        public Boolean Locked { get; set; }
        public string Color { get; set; }
        public ushort A { get; set; }
        public ushort B { get; set; }
        public ushort C { get; set; }
    }
}
