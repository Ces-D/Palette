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
        public string Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Hsv(string role, bool locked, string color)
        {
            Role = role;
            Locked = locked;
            Color = color;
        }

        //public static bool FormatValidator(string hsv)
        //{
        //    Regex template = new(@"(\d{1,3}),(0|1),(0|1)");
        //}
    }
}
