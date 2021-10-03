using Palette.Core.Infrastructure.Exceptions;
using Palette.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure.Models.Colors
{
    public class Rgb : IColor
    { 
        public string Role { get; set; }
        public bool Locked { get; set; }
        public string Color { get => Color; set { if (FormatValidator(value)) { Color = value; } } }

        public Rgb(string color)
        {
            Role = "Unkown";
            Locked = false;
            Color = color;
        }

        public Rgb(string role, bool locked, string color)
        {
            Role = role;
            Locked = locked;
            Color = color;
        }

        public static bool FormatValidator(string color)
        {
            Regex template = new(@"/rgb\((\d{1,3}), (\d{1,3}), (\d{1,3})\)/");
            Match match = template.Match(color);
            if (match.Success)
            {
                Regex digits = new(@"(\d{1,3})");
                MatchCollection values = digits.Matches(color);
                foreach(Match v in values)
                {
                    byte.Parse(v.Value);
                }
                return true;
            }
            else return false;
        }
    }
}
