using Palette.Core.Infrastructure.Exceptions;
using Palette.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure.Models.Colors
{
    public class Hex : IColor
    {
        public string Role { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Locked { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Color { get => Color; set { if (FormatValidator(value)) { Color = value; } } }

        public Hex(string role, bool locked, string color)
        {
            Role = role;
            Locked = locked;
            Color = color;
        }

        public Hex(string color)
        {
            Role = "Unkown";
            Locked = false;
            Color = color;
        }

        public static bool FormatValidator(string hex)
        {
            Regex template = new(@"^#([a-fA-F0-9]{6}|[a-fA-F0-9]{3})");
            Match match = template.Match(hex);
            if (match.Success)
            {
                return true;
            }
            else
            {
                throw new ColorFormatException($"Your RGB input string is incorrectly entered: {hex}");
            }
        }
    }
}
