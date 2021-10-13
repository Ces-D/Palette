using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Core.Domain.Exceptions;

namespace Core.Domain.Entities
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
        public override string ToString() => $"hsv({Hue}, {Saturation}%, {Value}%)";
    }
}

//https://www.ssw.com.au/rules/rules-to-better-clean-architecture
// TODO: find a place and move the conversion functions 
// TODO: delete the old Palette.Core