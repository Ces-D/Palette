using Palette.Core.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// see: https://en.wikipedia.org/wiki/HSL_and_HSV
namespace Palette.Core.Infrastructure.Models.Colors
{
    public class Hsv : IColorFormat<int>
    {
        public string Color { get; init; }
        public int A { get; init; }
        public int B { get; init; }
        public int C { get; init; }

        public Hsv(int a, int b, int c)
        {
            string hsv = $"hsv({a}, {b}%, {c}%)";
            if (FormatValidator(hsv) && a < 360 && b <= 100 && c <= 100)
            {
                A = a;
                B = b;
                C = c;
                Color = hsv;
            }
            else throw new ColorFormatException("HSV", $"hsv({a}, {b}%, {c}%)");

        }

        public static bool FormatValidator(string hsv)
        {
            Regex template = new(@"hsv\((\d{1,3}), (\d{1,3})%, (\d{1,3})%\)");
            Match match = template.Match(hsv);
            if (match.Success)
            {
                Regex digits = new(@"(\d{1,3})");
                MatchCollection values = digits.Matches(hsv);
                foreach (Match v in values)
                {
                    if (uint.TryParse(v.Value, out _)) { continue; } else return false;
                }
                return true;
            }
            else return false;
        }

        // see - https://www.had2know.com/technology/hsv-rgb-conversion-formula-calculator.html#:~:text=Converting%20HSV%20to%20RGB%20Given%20the%20values%20of,M%20%3D%20255V%20m%20%3D%20M%20%281-S%29.%20
        public static Rgb ToRgb(Hsv hsv)
        {
            byte R;
            byte G;
            byte B;
            double M = 255 * ((double)hsv.C / 100);
            double m = M * (1 - ((double)hsv.B / 100));

            double z = (M - m) * (1 - (Math.Abs(((double)hsv.A / 60) % 2 - 1)));

            if (0 <= hsv.A && hsv.A < 60)
            {
                R = Convert.ToByte(M);
                G = Convert.ToByte(z + m);
                B = Convert.ToByte(m);
                return new Rgb(R, G, B);
            }
            else if (60 <= hsv.A && hsv.A < 120)
            {
                R = Convert.ToByte(z + m);
                G = Convert.ToByte(M);
                B = Convert.ToByte(m);
                return new Rgb(R, G, B);
            }
            else if (120 <= hsv.A && hsv.A < 180)
            {
                R = Convert.ToByte(m);
                G = Convert.ToByte(M);
                B = Convert.ToByte(z + m);
                return new Rgb(R, G, B);
            }
            else if (180 <= hsv.A && hsv.A < 240)
            {
                R = Convert.ToByte(m);
                G = Convert.ToByte(z + m);
                B = Convert.ToByte(M);
                return new Rgb(R, G, B);
            }
            else if (240 <= hsv.A && hsv.A < 300)
            {
                R = Convert.ToByte(z + m);
                G = Convert.ToByte(m);
                B = Convert.ToByte(M);
                return new Rgb(R, G, B);
            }
            else if (300 <= hsv.A && hsv.A < 360)
            {
                R = Convert.ToByte(M);
                G = Convert.ToByte(m);
                B = Convert.ToByte(z + m);
                return new Rgb(R, G, B);
            }
            else return new Rgb(0, 0, 0);
        }

        public static Hex ToHex(Hsv hsv)
        {
            Rgb rgb = Hsv.ToRgb(hsv);
            return Rgb.ToHex(rgb);
        }
    }
}
