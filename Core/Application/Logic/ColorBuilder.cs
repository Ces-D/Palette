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
            var guid = Guid.NewGuid().ToString();
            return new Color()
            {
                Id = guid,
                Rgb = rgb,
                Hsv = hsv,
                Hex = hex
            };
        }
        public static Color BuildFromRgb(string rgbString, string colorId)
        {
            var rgb = Rgb.From(rgbString);
            var hsv = rgb.ToHsv();
            var hex = rgb.ToHex();
            var guid = colorId;
            return new Color()
            {
                Id = guid,
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
            var guid = Guid.NewGuid().ToString();
            return new Color()
            {
                Id = guid,
                Rgb = rgb,
                Hsv = hsv,
                Hex = hex
            };
        }

        public static Color BuildFromHex(string hexString, string colorId)
        {
            var hex = Hex.From(hexString);
            var rgb = hex.ToRgb();
            var hsv = hex.ToHsv();
            var guid = colorId;
            return new Color()
            {
                Id = guid,
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
            var guid = Guid.NewGuid().ToString();
            return new Color()
            {
                Id = guid,
                Rgb = rgb,
                Hsv = hsv,
                Hex = hex
            };
        }
        public static Color BuildFromHsv(string hsvString, string colorId)
        {
            var hsv = Hsv.From(hsvString);
            var hex = hsv.ToHex();
            var rgb = hsv.ToRgb();
            var guid = colorId;
            return new Color()
            {
                Id = guid,
                Rgb = rgb,
                Hsv = hsv,
                Hex = hex
            };
        }
    }
}
