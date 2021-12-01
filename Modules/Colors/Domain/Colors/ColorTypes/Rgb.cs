using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Palette.Base.Domain;

namespace Palette.Modules.Palettes.Domain.Colors.ColorTypes
{
    public record Rgb : ValueObject, IColorType
    {
        public byte Red { get; }
        public byte Green { get; }
        public byte Blue { get; }

        public ColorType ColorType { get; }

        private Rgb(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
            ColorType = ColorType.Rgb;
        }

        public static Rgb Create(string rgbColor)
        {
            var rgbFormatPattern = new Regex(@"rgb\((\d{1,3}), (\d{1,3}), (\d{1,3})\)");
            if (rgbFormatPattern.IsMatch(rgbColor))
            {
                string rgbNonDigitPattern = @"\D+";
                var digits = Regex.Split(rgbColor, rgbNonDigitPattern); // split by non digits
                var red = byte.Parse(digits[1]);
                var green = byte.Parse(digits[2]);
                var blue = byte.Parse(digits[3]);
                return new Rgb(red, green, blue);
            }
            else { throw new ArgumentException("Invalid rgb string", nameof(rgbColor)); }
        }

        public IColorType ConvertTo(ColorType toType)
        {
            switch (toType)
            {
                case ColorType.Hsl:
                    return this.ToHsl();
                default:
                    return this;
            }
        }

        private Hsl ToHsl()
        {
            if (Red == 255 && Green == 255 && Blue == 255) { return Hsl.Create($"hsl(0, 0%, 100%)"); }  // white
            if (Red == 0 && Green == 0 && Blue == 0) { return Hsl.Create("hsl(0, 0%, 0%)"); } // black

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
                return Hsl.Create($"hsl({Math.Round(H)}, {Math.Round(S * 100)}%, {Math.Round(L * 100)}%)");
            }
            else
            {
                double H = 360 - arcCosine * (180 / Math.PI);
                return Hsl.Create($"hsl({Math.Round(H)}, {Math.Round(S * 100)}%, {Math.Round(L * 100)}%)");
            }
        }
    }
}