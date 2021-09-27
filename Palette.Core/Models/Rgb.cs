using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Palette.Core.Infrastructure.Exceptions;

namespace Palette.Core.Models
{
    public class Rgb
    {
        public byte R { get; init; }
        public byte G{ get; init; }
        public byte B { get; init; }
        
        // (255,255,255)
        public Rgb(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        // rgb(255,255,255)
        public Rgb(string rgb)
        {
            Regex template = new Regex(@"/rgb\((\d{1,3}), (\d{1,3}), (\d{1,3})\)/");
            MatchCollection matches = template.Matches(rgb);
            if (matches.Count == 3) 
            {
                List<byte> rgbVals = matches.Cast<byte>().ToList();
                R = rgbVals[0];
                G = rgbVals[1];
                B = rgbVals[2];
            } else throw new ColorFormatException($"Your RGB input string is incorrectly entered: {rgb}");
        }
    }
}
