using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Entities;
using Core.Domain.ValueObjects;

namespace Core.Application.Logic
{
    public static class ColorBuilder
    {
        public static ColorEntity BuildFromRgb(string rgbString, string colorId = null)
        {
            var rgb = Rgb.From(rgbString);
            var hsv = rgb.ToHsv();
            var hex = rgb.ToHex();
            var hsl = rgb.ToHsl();
            var guid = colorId ?? Guid.NewGuid().ToString();
            return new ColorEntity()
            {
                Id = guid,
                Rgb = rgb,
                Hsv = hsv,
                Hex = hex,
                Hsl = hsl,
            };
        }

        public static ColorEntity BuildFromHex(string hexString, string colorId = null)
        {
            var hex = Hex.From(hexString);
            var rgb = hex.ToRgb();
            var hsv = hex.ToHsv();
            var hsl = hex.ToHsl();
            var guid = colorId ?? Guid.NewGuid().ToString();
            return new ColorEntity()
            {
                Id = guid,
                Rgb = rgb,
                Hsv = hsv,
                Hex = hex,
                Hsl = hsl,
            };
        }

        public static ColorEntity BuildFromHsv(string hsvString, string colorId = null)
        {
            var hsv = Hsv.From(hsvString);
            var hex = hsv.ToHex();
            var rgb = hsv.ToRgb();
            var hsl = hsv.ToHsl();
            var guid = colorId ?? Guid.NewGuid().ToString();
            return new ColorEntity()
            {
                Id = guid,
                Rgb = rgb,
                Hsv = hsv,
                Hex = hex,
                Hsl = hsl
            };
        }

        public static ColorEntity BuildFromHsl(string hslString, string colorId = null)
        {
            var hsl = Hsl.From(hslString);
            var hex = hsl.ToHex();
            var rgb = hsl.ToRgb();
            var hsv = hsl.ToHsv();
            var guid = colorId ?? Guid.NewGuid().ToString();
            return new ColorEntity()
            {
                Id = guid,
                Rgb = rgb,
                Hex = hex,
                Hsv = hsv,
                Hsl = hsl
            };
        }
    }
}


// TODO: Add builder functions for the new kind of from Constructors on each ColorType