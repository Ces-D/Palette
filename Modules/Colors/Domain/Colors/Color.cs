using Palette.Base.Domain;
using Palette.Modules.Palettes.Domain.Colors.ColorTypes;
using Palette.Modules.Palettes.Domain.Colors.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Modules.Palettes.Domain.Colors
{
    public class Color : Entity
    {
        public ColorId Id { get; private set; }
        private ColorType _colorType;
        private IColorType _color;

        private Color(ColorType colorType, IColorType color)
        {
            this.CheckRule(new ColorTypeAndIColorTypeRepresentTheSameColorFormatRule(colorType, color));

            Id = new ColorId(Guid.NewGuid());
            _colorType = colorType;
            _color = color;
            // TODO: figure out where AddDomainEvents fit in - https://github.com/kgrzybek/modular-monolith-with-ddd/blob/master/src/Modules/Meetings/Domain/MeetingGroupProposals/MeetingGroupProposal.cs
        }

        public static Color CreateNew(ColorType colorType, IColorType color)
        {
            return new Color(colorType, color);
        }

        internal void UpdateColorValues(ColorType colorType, IColorType color)
        {
            this.CheckRule(new ColorTypeAndIColorTypeRepresentTheSameColorFormatRule(colorType, color));

            _colorType = colorType;
            _color = color;
        }

        internal bool IsActiveInPalette(ColorId colorId)
        {
            return colorId == Id;
        }
    }
}
