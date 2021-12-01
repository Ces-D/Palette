using Pallete.Base.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Modules.Palettes.Domain.Colors
{
    public record ColorId : TypedIdValueBase
    {
        public ColorId(Guid id) : base(id) { }
    }
}
