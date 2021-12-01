using Palette.Base.Domain;
using Palette.Modules.Palettes.Domain.Authors;
using Palette.Modules.Palettes.Domain.Colors;
using Palette.Modules.Palettes.Domain.Palettes.Rules;
using Palette.Modules.Palettes.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Modules.Palettes.Domain.Palettes
{
    public class Palette : Entity
    {
        public PaletteId Id { get; private set; }
        private string _name;
        private AuthorId _authorId;
        private List<Color> _colorPalette;
        private DateTime _createDate;
        private int _maxLength;

        private Palette(string name, AuthorId authorId)
        {
            Id = new PaletteId(Guid.NewGuid());
            _name = name;
            _authorId = authorId;
            _colorPalette = new List<Color>();
            _createDate = SystemClock.Now;
            _maxLength = 10;
        }

        internal static Palette CreateNew(string name, AuthorId authorId)
        {
            return new Palette(name, authorId);
        }

        public void AddColor(Color color)
        {
            this.CheckRule(new PaletteColorsExceedsLengthLimit(10, _colorPalette.Count));
            this.CheckRule(new ColorCanOnlyBeAddedOnceRule(_colorPalette, color.Id));
            _colorPalette.Add(color);

            // TODO; send event 
        }

    }
}

// TODO: https://github.com/kgrzybek/modular-monolith-with-ddd/blob/master/src/Modules/Meetings/Domain/Meetings/Meeting.cs FINISH