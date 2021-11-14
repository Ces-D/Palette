using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Entities;

namespace Core.Application.Logic
{
    public class ComplimentaryColorBuilder
    {
        private ColorEntity _primary { get; set; }
        public ComplimentaryColorBuilder(ColorEntity color)
        {
            _primary = color;
        }

        public ComplimentaryHarmony Create()
        {
            var complimentaryHarmony = new ComplimentaryHarmony
            {
                Primary = _primary
            };

            if (_primary.Hsv.Hue == 0 && _primary.Hsv.Saturation == 0 && _primary.Hsv.Value == 0) // compliment of black is white
            {
                complimentaryHarmony.Compliment = ColorBuilder.BuildFromHsv("hsv(0, 0%, 100%)");
            }
            else if (_primary.Hsv.Hue == 0 && _primary.Hsv.Saturation == 0 && _primary.Hsv.Value == 100) // compliment of white is black
            {
                complimentaryHarmony.Compliment = ColorBuilder.BuildFromHsv("hsv(0, 0%, 0%)");
            }
            else
            {
                var complimentH = _primary.Hsv.Hue - 180;
                if (complimentH < 0)
                {
                    complimentH = 360 - complimentH;
                }
                var compliment = ColorBuilder.BuildFromHsv($"hsv({complimentH}, {_primary.Hsv.Saturation}%, {_primary.Hsv.Value}%");
                complimentaryHarmony.Compliment = compliment;

            }

            return complimentaryHarmony;
        }
    }
}
