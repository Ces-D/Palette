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
    public class Hsv : IColorType, IHsv
    {
        private Hsv() { }

        public static Hsv From(string hsvString)
        {
            try
            {
                var hsv = new Hsv();

                var hsvFormatPattern = new Regex(@"hsv\((\d{1,3}), (\d{1,3})%, (\d{1,3})%\)");
                if (hsvFormatPattern.IsMatch(hsvString))
                {
                    string hsvNonDigitPattern = @"\D+";
                    var digits = Regex.Split(hsvString, hsvNonDigitPattern); // split by non digits
                    var H = float.Parse(digits[1]);
                    var S = float.Parse(digits[2]);
                    var V = float.Parse(digits[3]);

                    if (H < 0 || H > 360) { throw new ArgumentOutOfRangeException("Hue", "Hue should be between 0 and 360"); }
                    if (S < 0 || S > 100) { throw new ArgumentOutOfRangeException("Saturation", "Saturation should be between 0 and 100"); }
                    if (V < 0 || V > 100) { throw new ArgumentOutOfRangeException("Value", "Value should be between 0 and 100"); }

                    hsv.Hue = H;
                    hsv.Saturation = S;
                    hsv.Value = V;
                }
                return hsv;
            }
            catch (Exception ex)
            {
                throw new HsvInvalidException(hsvString, ex);
            }

        }

        public static Hsv From(double hue, double saturation, double value)
        {
            var hsv = new Hsv();

            try
            {
                if (hue < 0 || hue > 360) { throw new ArgumentOutOfRangeException("Hue", "Hue should be between 0 and 360"); }
                if (saturation < 0 || saturation > 100) { throw new ArgumentOutOfRangeException("Saturation", "Saturation should be between 0 and 100"); }
                if (value < 0 || value > 100) { throw new ArgumentOutOfRangeException("Value", "Value should be between 0 and 100"); }
            }
            catch (Exception ex)
            {
                throw new HsvInvalidException($"hsv({hue}, {saturation}%, {value}%)", ex);
            }

            hsv.Hue = hue;
            hsv.Saturation = saturation;
            hsv.Value = value;

            return hsv;
        }

        public double Hue { get; private set; }
        public double Saturation { get; private set; }
        public double Value { get; private set; }
        public string Color { get { return ToString(); } }


        // see - https://www.had2know.com/technology/hsv-rgb-conversion-formula-calculator.html#:~:text=Converting%20HSV%20to%20RGB%20Given%20the%20values%20of,M%20%3D%20255V%20m%20%3D%20M%20%281-S%29.%20
        public Rgb ToRgb()
        {
            double R = 0;
            double G = 0;
            double B = 0;
            double M = 255 * (Value / 100);
            double m = M * (1 - (Saturation / 100));

            double z = (M - m) * (1 - Math.Abs((Hue / 60) % 2 - 1));

            if (0 <= Hue && Hue < 60)
            {
                R = Math.Round(M);
                G = Math.Round(z + m);
                B = Math.Round(m);
            }
            else if (60 <= Hue && Hue < 120)
            {
                R = Math.Round(z + m);
                G = Math.Round(M);
                B = Math.Round(m);
            }
            else if (120 <= Hue && Hue < 180)
            {
                R = Math.Round(m);
                G = Math.Round(M);
                B = Math.Round(z + m);
            }
            else if (180 <= Hue && Hue < 240)
            {
                R = Math.Round(m);
                G = Math.Round(z + m);
                B = Math.Round(M);
            }
            else if (240 <= Hue && Hue < 300)
            {
                R = Math.Round(z + m);
                G = Math.Round(m);
                B = Math.Round(M);
            }
            else if (300 <= Hue && Hue < 360)
            {
                R = Math.Round(M);
                G = Math.Round(m);
                B = Math.Round(z + m);
            }

            return Rgb.From($"rgb({R}, {G}, {B})");
        }

        public Hex ToHex()
        {
            var rgb = ToRgb();
            return rgb.ToHex();
        }

        public Hsl ToHsl()
        {
            var rgb = ToRgb();
            return rgb.ToHsl();
        }

        public override string ToString() => $"hsv({Hue}, {Saturation}%, {Value}%)";

        public static implicit operator string(Hsv hsv) => hsv.ToString();
    }
}

// https://www.ssw.com.au/rules/rules-to-better-clean-architecture
// https://www.dandoescode.com/blog/clean-architecture-an-introduction/