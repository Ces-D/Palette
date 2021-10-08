using Palette.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure.Models.Colors
{
    public class Color
    {
        public string Role { get; set; }
        public bool Locked { get; set; }
        public Rgb Rgb { get; set; }
        public Hex Hex { get; set; }
        public Hsv Hsv { get; set; }

    }
}
