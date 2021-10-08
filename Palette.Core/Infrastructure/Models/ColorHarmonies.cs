using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Palette.Core.Infrastructure.Models.Colors;

namespace Palette.Core.Infrastructure.Models
{
    public class ColorHarmonies
    {
        private readonly Color _color;

        public ColorHarmonies(Color color)
        {
            _color = color;
        }

        public IEnumerable<Color> Complimentary()
        {
            Color compliment = new();

            int complimentHue = _color.Hsv.A - 180;
            if (complimentHue < 0)
            {
                complimentHue = 360 - complimentHue;
            }
            else if (complimentHue == 0)
            { complimentHue = 359; }

            compliment.Hsv = new Hsv(complimentHue, _color.Hsv.B, _color.Hsv.C);

            return new List<Color> { _color, compliment };
        }
    }
}
