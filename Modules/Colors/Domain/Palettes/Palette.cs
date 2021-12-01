using Palette.Base.Domain;
using Palette.Modules.Palettes.Domain.Authors;
using Palette.Modules.Palettes.Domain.Colors;
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
        private List<Color> _colors;
        private DateTime _createDate;

        private Palette(string name, AuthorId authorId)
        {
            Id = new PaletteId(Guid.NewGuid());
            _name = name;
            _authorId = authorId;
            _colors = new List<Color>();
            _createDate = SystemClock.Now;
        }

        internal static Palette CreateNew(string name, AuthorId authorId)
        {
            return new Palette(name, authorId);
        }

        public void AddColor(Color color)
        {
            // TODO: add rules; i.e is the same color added more than once, do i want a limit on the length of the palette - yes
            _colors.Add(color);
        }

    }
}

// TODO: https://github.com/kgrzybek/modular-monolith-with-ddd/blob/master/src/Modules/Meetings/Domain/Meetings/Meeting.cs FINISH