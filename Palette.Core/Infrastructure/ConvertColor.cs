using Palette.Core.Infrastructure.Models.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure
{
    public static class ConvertColor
    {
        public static Rgb ToRgb(Hex hex)
        {
            byte r = Convert.ToByte(hex.A, 16);
            byte g = Convert.ToByte(hex.B, 16);
            byte b = Convert.ToByte(hex.C, 16);
            return new Rgb(r, g, b);
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

        //public static Hsv ToHsv(Hex hex) { }

        // see - https://github.com/LeoSimp/ColorConverter/blob/master/ColorConverter.cs
        public static Hsv ToHsv(Rgb rgb)
        {
            double M = (double)System.Math.Max(rgb.A, System.Math.Max(rgb.B, rgb.C));
            double m = (double)System.Math.Min(rgb.A, Math.Min(rgb.B, rgb.C));

            double H = 0;
            if (M == m)
            {
                H = 0;
            }
            else if (M == (double)rgb.A && rgb.B > rgb.C)
            {
                H = (double)(60f * (rgb.B - rgb.C) / (M - m) + 0);
            }
            else if (M == rgb.A && rgb.B < rgb.C)
            {
                H = (double)(60f * (rgb.B - rgb.C) / (M - m) + 360);
            }
            else if (M == rgb.B)
            {
                H = (double)(60f * (rgb.B - rgb.A) / (M - m) + 120);
            }
            else if (M == rgb.C)
            {
                H = (double)(60f * (rgb.A - rgb.B) / (M - m) + 240);
            }

            double S = M != 0 ? (M - m) * 1.0f / M : 0; // FIXME: This might be where the issue in calculation is
            double V = M / 255;
            return new Hsv((uint)H, (uint)S, (uint)V);

        }
    }
}
