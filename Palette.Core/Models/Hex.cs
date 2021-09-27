using Palette.Core.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palette.Core.Models
{
    public class Hex
    {
        public string R { get; init; }
        public string G { get; init; }
        public string B { get; init; }


        // #ffffff
        public Hex(string hex)
        {
            int hexLength = hex.Length;
            if (hexLength == 6 || hexLength == 3)
            {
                Regex template = new Regex(@"^#([a-fA-F0-9]{6}|[a-fA-F0-9]{3})");
                Match match = template.Match(hex);               
                if (hexLength == 3)
                {
                    R = match.Value.Substring(0,1);
                    G = match.Value.Substring(1, 1);
                    B = match.Value.Substring(2, 1);
                } else
                {
                    R = match.Value.Substring(0, 2);
                    G = match.Value.Substring(2, 2);
                    B = match.Value.Substring(4, 2);
                }
            }
            else throw new ColorFormatException($"Your HEX input string is incorrectly entered: {hex}");
        }

    }
}
