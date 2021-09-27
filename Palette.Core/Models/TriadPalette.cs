using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.Models
{
    // https://www.color-meanings.com/color-wheel-theory-complementary-colors/
    public class TriadPalette : IPalette
    {
        public byte MaxLength { get; } = 20;
        public ICollection<IColor> Colors { get; set; }
        public string ColorHarmony { get; } = "Triad";
    }
}
