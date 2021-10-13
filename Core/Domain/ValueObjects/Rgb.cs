using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Core.Domain.Exceptions;

namespace Core.Domain.ValueObjects
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

        // see - https://github.com/LeoSimp/ColorConverter/blob/master/ColorConverter.cs
        public Hsv ToHsv()
        {
            if (Red == byte.MaxValue && Green == byte.MaxValue && Blue == byte.MaxValue) { return Hsv.From($"hsv(0, 0%, 100%)"); }  // white
            if (Red == byte.MinValue && Green == byte.MinValue && Blue == byte.MinValue) { return Hsv.From("hsv(0, 0%, 0%)"); } // black

            double R = (double)Red;
            double G = (double)Green;
            double B = (double)Blue;
            double M = Math.Max(R, Math.Max(G, B));
            double m = Math.Min(R, Math.Min(G, B));

            double V = (M / 255) * 100;
            double S = M > 0 ? (1 - (m / M)) * 100 : 0;
            double sqrtPortion = Math.Pow(R, 2) + Math.Pow(G, 2) + Math.Pow(B, 2) - (R * G) - (R * B) - (G * B);
            double D = (R - (0.5 * G) - (0.5 * B)) / Math.Sqrt(sqrtPortion);

            if (G >= B)
            {
                double Hrads = Math.Acos(D);
                double H = Hrads * (180 / Math.PI); // Converting from radians to degrees
                return Hsv.From($"hsv({H}, {S}%, {V}%)");
            }
            else
            {
                double H = 360 - Math.Acos(D);
                return Hsv.From($"hsv({H}, {S}%, {V}%)");
            }
        }

        public Hex ToHex()
        {
            string A = String.Format("{0:X2}", Red);
            string B = String.Format("{0:X2}", Green);
            string C = String.Format("{0:X2}", Blue);

            return Hex.From($"#{A}{B}{C}");
        }
        public override string ToString() => $"rgb({Red}, {Green}, {Blue})";


    }
}
