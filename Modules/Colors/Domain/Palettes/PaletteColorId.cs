using Pallete.Base.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Modules.Palettes.Domain.Palettes
{
    public record PaletteColorId : TypedIdValueBase
    {
        public PaletteColorId(Guid id) : base(id) { }
    }
}
