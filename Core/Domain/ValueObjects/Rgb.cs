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
    public class Rgb : IColorType, IRgb
    {
        private Rgb() { }

        public static Rgb From(string rgbString)
        {

            var rgb = new Rgb();

            var rgbFormatPattern = new Regex(@"rgb\((\d{1,3}), (\d{1,3}), (\d{1,3})\)");
            if (rgbFormatPattern.IsMatch(rgbString))
            {
                string rgbNonDigitPattern = @"\D+";
                var digits = Regex.Split(rgbString, rgbNonDigitPattern); // split by non digits
                rgb.Red = byte.Parse(digits[1]);
                rgb.Green = byte.Parse(digits[2]);
                rgb.Blue = byte.Parse(digits[3]);
                return rgb;
            }
            else { throw new RgbInvalidException(rgbString); }
        }

        public static Rgb From(byte red, byte green, byte blue)
        {
            var rgb = new Rgb
            {
                Red = red,
                Green = green,
                Blue = blue
            };
            return rgb;
        }

        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }
        public string Color { get { return ToString(); } }


        //see - https://www.had2know.com/technology/hsv-rgb-conversion-formula-calculator.html#:~:text=Converting%20HSV%20to%20RGB%20Given%20the%20values%20of,M%20%3D%20255V%20m%20%3D%20M%20%281-S%29.
        public Hsv ToHsv()
        {
            if (Red == 255 && Green == 255 && Blue == 255) { return Hsv.From($"hsv(0, 0%, 100%)"); }  // white
            if (Red == 0 && Green == 0 && Blue == 0) { return Hsv.From("hsv(0, 0%, 0%)"); } // black

            double R = (double)Red;
            double G = (double)Green;
            double B = (double)Blue;
            var M = Math.Max(R, Math.Max(G, B));
            var m = Math.Min(R, Math.Min(G, B));

            // value
            var V = (M / 255) * 100;
            //saturation
            var S = M > 0 ? (1 - (m / M)) * 100 : 0;

            // hue
            var sqrtPortion = Math.Pow(R, 2) + Math.Pow(G, 2) + Math.Pow(B, 2) - (R * G) - (R * B) - (G * B);
            var D = (R - (0.5 * G) - (0.5 * B)) / Math.Sqrt(sqrtPortion);
            var arcCosine = Math.Acos(D);

            if (G >= B)
            {
                double H = arcCosine * (180 / Math.PI); // Converting from radians to degrees
                return Hsv.From($"hsv({Math.Round(H)}, {Math.Round(S)}%, {Math.Round(V)}%)");
            }
            else
            {
                double H = 360 - arcCosine * (180 / Math.PI);
                return Hsv.From($"hsv({Math.Round(H)}, {Math.Round(S)}%, {Math.Round(V)}%)");
            }
        }

        //see - https://www.had2know.com/technology/hsl-rgb-color-converter.html
        public Hsl ToHsl()
        {
            if (Red == 255 && Green == 255 && Blue == 255) { return Hsl.From($"hsl(0, 0%, 100%)"); }  // white
            if (Red == 0 && Green == 0 && Blue == 0) { return Hsl.From("hsl(0, 0%, 0%)"); } // black

            double R = (double)Red;
            double G = (double)Green;
            double B = (double)Blue;
            var M = Math.Max(R, Math.Max(G, B));
            var m = Math.Min(R, Math.Min(G, B));
            var d = (M - m) / 255;

            // lightness
            var L = (M + m) / 510;
            // saturation
            var S = L > 0 ? d / (1 - Math.Abs(2 * L - 1)) : 0;

            // hue
            var sqrtPortion = Math.Pow(R, 2) + Math.Pow(G, 2) + Math.Pow(B, 2) - (R * G) - (R * B) - (G * B);
            var D = (R - (0.5 * G) - (0.5 * B)) / Math.Sqrt(sqrtPortion);
            var arcCosine = Math.Acos(D);

            if (G >= B)
            {
                double H = arcCosine * (180 / Math.PI); // Coverting from radians to degrees
                return Hsl.From($"hsl({Math.Round(H)}, {Math.Round(S * 100)}%, {Math.Round(L * 100)}%)");
            }
            else
            {
                double H = 360 - arcCosine * (180 / Math.PI);
                return Hsl.From($"hsl({Math.Round(H)}, {Math.Round(S * 100)}%, {Math.Round(L * 100)}%)");
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

        public static implicit operator string(Rgb rgb) => rgb.ToString();

    }
}
