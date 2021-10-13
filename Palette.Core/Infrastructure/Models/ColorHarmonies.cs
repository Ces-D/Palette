using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Palette.Core.Infrastructure.Models.Colors;

namespace Palette.Core.Infrastructure.Models
{
    public class ColorHarmonies
    {
        public Color Primary { get; set; }
        public ColorHarmonies(Color primary)
        {
            Primary = primary;
        }

        public List<Color> Complimentary()
        {
            if (Primary.Hsv.A == 0 && Primary.Hsv.B == 0 && Primary.Hsv.C == 100) return new List<Color> { Primary, Primary }; // white
            if (Primary.Hsv.A == 0 && Primary.Hsv.B == 0 && Primary.Hsv.C == 0) return new List<Color> { Primary, Primary }; // black

            int complimentH = Primary.Hsv.A - 180;
            if (complimentH < 0)
            {
                complimentH = 360 - complimentH;
            }
            Hsv complimentHsv = new(complimentH, Primary.Hsv.B, Primary.Hsv.C);

            return new List<Color> { Primary, new Color(complimentHsv) };
        }
    }
}
