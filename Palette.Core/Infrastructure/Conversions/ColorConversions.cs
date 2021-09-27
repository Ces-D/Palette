using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure
{
    public static  class ColorConversions
    {

        /// <summary>
        /// Convert RGB to HSL.
        /// </summary>
        /// <param name="R">Red value between 0 and 1.</param>
        /// <param name="G">Green value between 0 and 1.</param>
        /// <param name="B">Blue value between 0 and 1.</param>
        /// <returns>Array with three elements containing H value between 0 and 360 and S and L value between 0 and 1.</returns>
        public static double[] RGBToHSL(double R, double G, double B)
        {
            double max = (double)Math.Max(Math.Max(R, G), B);
            double min = (double)Math.Min(Math.Min(R, G), B);
            double diff = max - min;
            double h = calcH(R, G, B, diff);
            double s = (max == 0 || min == 1) ? 0 : diff / (1 - Math.Abs(max + min - 1));
            double l = (max + min) / 2;
            return new double[] { h, s, l };
        }

        private static double calcH(double r, double g, double b, double diff)
        {
            if (r == g && g == b)
                return 0;
            else if (r >= g && r >= b)
                return hueTerm(0, g, b, diff);
            else if (g >= r && g >= b)
                return hueTerm(2, b, r, diff);
            else
                return hueTerm(4, r, g, diff);
        }

        private static double hueTerm(int s, double n1, double n2, double diff)
        {
            double res = 60 * (s + (n1 - n2) / diff);
            return res > 0 ? res : res + 360;
        }

        /// <summary>
        /// Convert HSL to RGB.
        /// </summary>
        /// <param name="H">Hue value between 0 and 360.</param>
        /// <param name="S">Saturation value between 0 and 1.</param>
        /// <param name="L">Lightness value between 0 and 1.</param>
        /// <returns>Array with three elements containing R, G and B value.</returns>
        public static double[] HSLToRGB(int H, double S, double L)
        {
            double C = (1 - Math.Abs(2 * L - 1)) * S;
            double hh = H / 60.0;
            double X = C * (1 - Math.Abs(hh % 2.0 - 1));
            double[] rgb = new double[] { 0, 0, 0 };
            if (hh <= 1)
                rgb = new double[] { C, X, 0 };
            else if (hh <= 2)
                rgb = new double[] { X, C, 0 };
            else if (hh <= 3)
                rgb = new double[] { 0, C, X };
            else if (hh <= 4)
                rgb = new double[] { 0, X, C };
            else if (hh <= 5)
                rgb = new double[] { X, 0, C };
            else if (hh <= 6)
                rgb = new double[] { C, 0, X };
            double m = L - 0.5 * C;
            rgb[0] += m; rgb[1] += m; rgb[2] += m;
            return rgb;
        }
    }

}

// TODO: take logic and delete