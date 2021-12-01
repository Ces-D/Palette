using Pallete.Base.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Modules.Palettes.Domain.Palettes
{
    public record PaletteId : TypedIdValueBase
    {
        public PaletteId(Guid id) : base(id) { }
    }
}
