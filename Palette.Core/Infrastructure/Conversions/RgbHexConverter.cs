using Palette.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure.Conversions
{
    public class RgbHexConverter
    {
        public Rgb Rgb { get; }
        public Hex Hex { get; }

        public RgbHexConverter(Rgb rgb, Hex hex)
        {
            Rgb = rgb;
            Hex = hex;
        }

        // TODO: complete the conversion
    }
}
