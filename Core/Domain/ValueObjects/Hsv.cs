﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Core.Domain.Exceptions;

namespace Core.Domain.ValueObjects
{
    public class Hsv
    {
        private Hsv() { }

        public static Hsv From(string hsvString)
        {
            var hsv = new Hsv();

            try
            {
                var hsvFormatPattern = new Regex(@"hsv\((\d{1,3}), (\d{1,3})%, (\d{1,3})%\)");
                if (hsvFormatPattern.IsMatch(hsvString))
                {
                    string hsvNonDigitPattern = @"\D+";
                    var digits = Regex.Split(hsvString, hsvNonDigitPattern); // split by non digits
                    var H = float.Parse(digits[0]);
                    var S = float.Parse(digits[1]);
                    var V = float.Parse(digits[2]);

                    if (H < 0 && H >= 360) throw new ArgumentOutOfRangeException("Hue", "Hue should be between 0 and 360");
                    if (S < 0 && S > 100) throw new ArgumentOutOfRangeException("Saturation", "Saturation should be between 0 and 100");
                    if (V < 0 && V > 100) throw new ArgumentOutOfRangeException("Value", "Value should be between 0 and 100");

                    hsv.Hue = H;
                    hsv.Saturation = S;
                    hsv.Value = S;
                }
            }
            catch (Exception ex)
            {
                throw new HsvInvalidException(hsvString, ex);
            }

            return hsv;
        }

        public float Hue { get; private set; }
        public float Saturation { get; private set; }
        public float Value { get; private set; }

        public static implicit operator string(Hsv hsv) => hsv.ToString();

        // see - https://www.had2know.com/technology/hsv-rgb-conversion-formula-calculator.html#:~:text=Converting%20HSV%20to%20RGB%20Given%20the%20values%20of,M%20%3D%20255V%20m%20%3D%20M%20%281-S%29.%20
        public Rgb ToRgb()
        {
            int R = 0;
            int G = 0;
            int B = 0;
            double M = 255 * (Value / 100);
            double m = M * (1 - (Saturation / 100));

            double z = (M - m) * (1 - (Math.Abs((Hue / 60) % 2 - 1)));

            if (0 <= Hue && Hue < 60)
            {
                R = Convert.ToByte(M);
                G = Convert.ToByte(z + m);
                B = Convert.ToByte(m);
            }
            else if (60 <= Hue && Hue < 120)
            {
                R = Convert.ToByte(z + m);
                G = Convert.ToByte(M);
                B = Convert.ToByte(m);
            }
            else if (120 <= Hue && Hue < 180)
            {
                R = Convert.ToByte(m);
                G = Convert.ToByte(M);
                B = Convert.ToByte(z + m);
            }
            else if (180 <= Hue && Hue < 240)
            {
                R = Convert.ToByte(m);
                G = Convert.ToByte(z + m);
                B = Convert.ToByte(M);
            }
            else if (240 <= Hue && Hue < 300)
            {
                R = Convert.ToByte(z + m);
                G = Convert.ToByte(m);
                B = Convert.ToByte(M);
            }
            else if (300 <= Hue && Hue < 360)
            {
                R = Convert.ToByte(M);
                G = Convert.ToByte(m);
                B = Convert.ToByte(z + m);
            }

            return Rgb.From($"rgb({R}, {G}, {B})");
        }
        public Hex ToHex()
        {
            var rgb = ToRgb();
            return rgb.ToHex();
        }
        public override string ToString() => $"hsv({Hue}, {Saturation}%, {Value}%)";
    }
}

// https://www.ssw.com.au/rules/rules-to-better-clean-architecture
// https://www.dandoescode.com/blog/clean-architecture-an-introduction/

// TODO: find a place and move the conversion functions 
// TODO: Complete tests for new core
// TODO: figure out how the react frontend connects to asp.net