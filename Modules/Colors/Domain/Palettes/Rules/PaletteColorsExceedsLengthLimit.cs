using Palette.Base.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Modules.Palettes.Domain.Palettes.Rules
{
    internal class PaletteColorsExceedsLengthLimit : IBusinessRule
    {
        private readonly int _colorLimit;
        private readonly int _colorLength;
        internal PaletteColorsExceedsLengthLimit(int colorLimit, int colorLength)
        {
            _colorLength = colorLength;
            _colorLimit = colorLimit;
        }
        public string Message => "Palette Colors cannot exceed the length limit";

        public bool IsBroken() => _colorLength + 1 > _colorLimit
    }
}
