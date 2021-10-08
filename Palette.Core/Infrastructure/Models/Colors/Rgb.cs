﻿using Palette.Core.Infrastructure.Exceptions;
using Palette.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure.Models.Colors
{
    public class Rgb : IColor<byte>
    {
        public string Color { get; init; }
        public byte A { get; init; }
        public byte B { get; init; }
        public byte C { get; init; }

        public Rgb(byte a, byte b, byte c)
        {
            string rgb = $"rgb({a}, {b}, {c})";
            if (FormatValidator(rgb))
            {
                A = a;
                B = b;
                C = c;
                Color = rgb;
            }
            else throw new ColorFormatException("Rgb", rgb);
        }

        public static bool FormatValidator(string color)
        {
            Regex template = new(@"rgb\((\d{1,3}), (\d{1,3}), (\d{1,3})\)");
            Match match = template.Match(color);
            if (match.Success)
            {
                Regex digits = new(@"(\d{1,3})");
                MatchCollection values = digits.Matches(color);
                foreach (Match v in values)
                {
                    if (byte.TryParse(v.Value, out _)) { continue; } else return false;
                }
                return true;
            }
            else return false;
        }

        // see - https://github.com/LeoSimp/ColorConverter/blob/master/ColorConverter.cs
        public static Hsv ToHsv(Rgb rgb)
        {
            double R = (double)rgb.A;
            double G = (double)rgb.B;
            double B = (double)rgb.C;
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
                return new Hsv((int)H, (int)S, (int)V);
            }
            else
            {
                double H = 360 - Math.Acos(D);
                return new Hsv((int)H, (int)S, (int)V);
            }
        }

        //TODO: public static Hex ToHex(Rgb rgb){}
    }
}
