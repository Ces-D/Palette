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
    public class Hsv : IColor
    {
        public string Role { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Locked { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Color { get { return Color; } set { if (Hsv.FormatValidator(value)) { Color = value; } } }

        public Hsv(string role, bool locked, string color)
        {
            Role = role;
            Locked = locked;
            Color = color;
        }
        public Hsv(string color)
        {
            Role = "unknown";
            Locked = false;
            Color = color;
        }

        // (100,1,1) | (23, 0.001, 0.25)
        public static bool FormatValidator(string color)
        {
            if (color.StartsWith('(') && color.EndsWith(')'))
            {
                color = color.TrimEnd(')').TrimStart('(');
                string[] vals = color.Split(',');
                if (vals.Length != 3) return false;
                if (!int.TryParse(vals[0], out int result)) { if (result >= 360) return false; };
                if (Decimal.TryParse(vals[1], out Decimal dec1) && Decimal.TryParse(vals[2], out Decimal dec2))
                {
                    if (0 <= dec1 && 0 <= dec2 && 1 >= dec1 && 1 >= dec2) { return true; } else return false;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
