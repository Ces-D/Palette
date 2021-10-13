using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.ViewModels
{
    public record ColorModel
    {
        public string Name { get; set; }
        public bool Locked { get; set; }
        public string Rgb { get; set; }
        public string Hex { get; set; }
        public string Hsv { get; set; }
    }
}
