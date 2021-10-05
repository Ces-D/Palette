using Palette.Core.Infrastructure.Exceptions;
using Palette.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// see: https://en.wikipedia.org/wiki/HSL_and_HSV
namespace Palette.Core.Infrastructure.Models.Colors
{
    public class Hsv : IColor<uint>
    {
        public string Role { get; init; }
        public bool Locked { get; init; }
        public string Color { get; init; }
        public uint A { get; init; }
        public uint B { get; init; }
        public uint C { get; init; }

        public Hsv(string role, bool locked, uint a, uint b, uint c)
        {
            Role = role;
            Locked = locked;
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

        public Hsv(uint a, uint b, uint c)
        {
            Role = "Uknown";
            Locked = false;
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
                    if (uint.TryParse(v.Value, out uint result)) { continue; } else return false;
                }
                return true;
            }
            else return false;
        }
    }
}
