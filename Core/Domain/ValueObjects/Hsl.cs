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
    public class Hsl : IColorType, IHsl
    {
        private Hsl() { }

        public static Hsl From(string hslString)
        {
            var hsl = new Hsl();

            try
            {
                var hslFormatPattern = new Regex(@"hsl\((\d{1,3}), (\d{1,3})%, (\d{1,3})%\)");
                if (hslFormatPattern.IsMatch(hslString))
                {
                    string hslNonDigitPattern = @"\D+";
                    var digits = Regex.Split(hslString, hslNonDigitPattern);
                    var H = double.Parse(digits[1]);
                    var S = double.Parse(digits[2]);
                    var L = double.Parse(digits[3]);

                    if (H < 0 || H > 360) { throw new ArgumentOutOfRangeException("Hue", "Hue should be between 0 and 360"); }
                    if (S < 0 || S > 100) { throw new ArgumentOutOfRangeException("Saturation", "Saturation should be between 0 and 100"); }
                    if (L < 0 || L > 100) { throw new ArgumentOutOfRangeException("Lightness", "Lightness should be between 0 and 100"); }

                    hsl.Hue = H;
                    hsl.Saturation = S;
                    hsl.Lightness = L;
                }
            }
            catch (Exception ex)
            {
                throw new HslInvalidException(hslString, ex);
            }
            return hsl;
        }

        public static Hsl From(double hue, double saturation, double lightness)
        {
            var hsl = new Hsl();

            try
            {
                if (hue < 0 || hue > 360) { throw new ArgumentOutOfRangeException("Hue", "Hue should be between 0 and 360"); }
                if (saturation < 0 || saturation > 100) { throw new ArgumentOutOfRangeException("Saturation", "Saturation should be between 0 and 100"); }
                if (lightness < 0 || lightness > 100) { throw new ArgumentOutOfRangeException("Lightness", "Lightness should be between 0 and 100"); }
            }
            catch (Exception ex)
            {
                throw new HslInvalidException($"hsl({hue}, {saturation}%, {lightness}%)", ex);
            }

            hsl.Hue = hue;
            hsl.Saturation = saturation;
            hsl.Lightness = lightness;

            return hsl;
        }

        public double Hue { get; private set; }
        public double Saturation { get; private set; }
        public double Lightness { get; private set; }
        public string Color { get { return ToString(); } }


        //see - https://www.had2know.com/technology/hsl-rgb-color-converter.html
        public Rgb ToRgb()
        {
            var L = Lightness / 100;
            var S = Saturation / 100;
            var d = S * (1 - Math.Abs(2 * L - 1));
            var m = 255 * (L - d / 2);

            var x = d * (1 - Math.Abs((Hue / 60) % 2 - 1));

            double R = 0;
            double G = 0;
            double B = 0;

            if (0 <= Hue && Hue < 60)
            {
                R = 255 * d + m;
                G = 255 * x + m;
                B = m;
            }
            else if (60 <= Hue && Hue < 120)
            {
                R = 255 * x + m;
                G = 255 * d + m;
                B = m;
            }
            else if (120 <= Hue && Hue < 180)
            {
                R = m;
                G = 255 * d + m;
                B = 255 * x + m;
            }
            else if (180 <= Hue && Hue < 240)
            {
                R = m;
                G = 255 * x + m;
                B = 255 * d + m;
            }
            else if (240 <= Hue && Hue < 300)
            {
                R = 255 * x + m;
                G = m;
                B = 255 * d + m;
            }
            else if (300 <= Hue && Hue < 360)
            {
                R = 255 * d + m;
                G = m;
                B = 255 * x + m;
            }

            return Rgb.From($"rgb({Math.Round(R)}, {Math.Round(G)}, {Math.Round(B)})");
        }

        public Hsv ToHsv()
        {
            var rgb = ToRgb();
            return rgb.ToHsv();
        }

        public Hex ToHex()
        {
            var rgb = ToRgb();
            return rgb.ToHex();
        }

        public override string ToString() => $"hsl({Hue}, {Saturation}%, {Lightness}%)";

        public static implicit operator string(Hsl hsl) => hsl.ToString();
    }
}
