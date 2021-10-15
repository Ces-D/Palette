using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Core.Domain.Exceptions;

namespace Core.Domain.ValueObjects
{
    public class Hex
    {
        private Hex() { }

        public static Hex From(string hexString)
        {
            var hex = new Hex();

            try
            {
                var hexFormatPattern = new Regex(@"^#([a-fA-F0-9]{6})");
                if (hexFormatPattern.IsMatch(hexString))
                {
                    hex.Red = hexString.Substring(1, 2).ToUpper();
                    hex.Green = hexString.Substring(3, 2).ToUpper();
                    hex.Blue = hexString.Substring(5, 2).ToUpper();
                }
            }
            catch (Exception ex)
            {
                throw new HexInvalidException(hexString, ex);
            }

            return hex;
        }

        public string Red { get; private set; }
        public string Green { get; private set; }
        public string Blue { get; private set; }

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

        public override string ToString() => $"#{Red}{Green}{Blue}";
    }
}
