using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Core.Domain.Exceptions;

namespace Core.Domain.Entities
{
    public class Rgb
    {
        private Rgb() { }

        public static Rgb From(string rgbString)
        {
            var rgb = new Rgb();

            try
            {
                var rgbFormatPattern = new Regex(@"rgb\((\d{1,3}), (\d{1,3}), (\d{1,3})\)");
                if (rgbFormatPattern.IsMatch(rgbString))
                {
                    string rgbNonDigitPattern = @"\D+";
                    var digits = Regex.Split(rgbString, rgbNonDigitPattern); // split by non digits
                    rgb.Red = byte.Parse(digits[0]);
                    rgb.Green = byte.Parse(digits[1]);
                    rgb.Blue = byte.Parse(digits[2]);
                }
            }
            catch (Exception ex)
            {
                throw new RgbInvalidException(rgbString, ex);
            }

            return rgb;
        }

        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public static implicit operator string(Rgb rgb) => rgb.ToString();
        public override string ToString() => $"rgb({Red}, {Green}, {Blue})";


    }
}
