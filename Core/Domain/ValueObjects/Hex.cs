using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;

namespace Core.Domain.ValueObjects
{
    public class Hex : IColorType, IHex
    {
        private Hex() { }

        public static Hex From(string hexString)
        {
            try
            {
                var hex = new Hex();

                var hexFormatPattern = new Regex(@"^#([a-fA-F0-9]{6})");
                if (hexFormatPattern.IsMatch(hexString))
                {
                    hex.Red = hexString.Substring(1, 2).ToUpper();
                    hex.Green = hexString.Substring(3, 2).ToUpper();
                    hex.Blue = hexString.Substring(5, 2).ToUpper();
                }
                return hex;
            }
            catch (Exception ex)
            {
                throw new HexInvalidException(hexString, ex);
            }

        }

        public string Red { get; private set; }
        public string Green { get; private set; }
        public string Blue { get; private set; }
        public string Color { get { return ToString(); } }

        public static implicit operator string(Hex hex) => hex.ToString();

        public Rgb ToRgb()
        {
            byte r = Convert.ToByte(Red, 16);
            byte g = Convert.ToByte(Green, 16);
            byte b = Convert.ToByte(Blue, 16);
            return Rgb.From($"rgb({r}, {g}, {b})");
        }

        public Hsv ToHsv()
        {
            var rgb = ToRgb();
            return rgb.ToHsv();
        }

        public Hsl ToHsl()
        {
            var rgb = ToRgb();
            return rgb.ToHsl();
        }

        public override string ToString() => $"#{Red}{Green}{Blue}";
    }
}
