using Palette.Base.Domain;
using Palette.Modules.Palettes.Domain.Colors.ColorTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Modules.Palettes.Domain.Colors.Rules
{
    internal class ColorTypeAndIColorTypeRepresentTheSameColorFormatRule : IBusinessRule
    {
        private readonly bool _formatsMatch;
        public ColorTypeAndIColorTypeRepresentTheSameColorFormatRule(ColorType colorType, IColorType color)
        {
            _formatsMatch = colorType.Equals(color.ColorType);
        }
        public string Message => "Color Type and Color implementation must represent the same color format";
        public bool IsBroken() => this._formatsMatch;
    }
}
