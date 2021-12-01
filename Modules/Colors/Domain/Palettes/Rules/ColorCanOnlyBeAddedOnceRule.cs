using Palette.Base.Domain;
using Palette.Modules.Palettes.Domain.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Modules.Palettes.Domain.Palettes.Rules
{
    internal class ColorCanOnlyBeAddedOnceRule : IBusinessRule
    {
        private readonly List<Color> _colors;
        private readonly ColorId _colorId;
        internal ColorCanOnlyBeAddedOnceRule(List<Color> colors, ColorId colorId)
        {
            _colors = colors;
            _colorId = colorId;
        }
        public string Message => "Color can only be added to a Palette once";

        public bool IsBroken()
        {
            var onlyOne = _colors.SingleOrDefault(c => c.IsActiveInPalette(_colorId));
            return onlyOne == null;
        }
    }
}
