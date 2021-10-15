using Core.Domain.Entities;
using Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Logic
{
    public static class ColorBuilder
    {
        public static Color BuildFromRgb(string rgbString)
        {
            var rgb = Rgb.From(rgbString);
            var hsv = rgb.ToHsv();
            var hex = rgb.ToHex();
            return new Color()
            {
                Rgb = rgb,
                Hsv = hsv,
                Hex = hex
            };
        }

        public static Color BuildFromHex(string hexString)
        {
            var hex = Hex.From(hexString);
            var rgb = hex.ToRgb();
            var hsv = hex.ToHsv();
            return new Color()
            {
                Rgb = rgb,
                Hsv = hsv,
                Hex = hex
            };
        }

        public static Color BuildFromHsv(string hsvString)
        {
            var hsv = Hsv.From(hsvString);
            var hex = hsv.ToHex();
            var rgb = hsv.ToRgb();
            return new Color()
            {
                Rgb = rgb,
                Hsv = hsv,
                Hex = hex
            };
        }
    }
}
