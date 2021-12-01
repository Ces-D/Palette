using Pallete.Base.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Modules.Palettes.Domain.Authors
{
    public record AuthorId : TypedIdValueBase
    {
        public AuthorId(Guid id) : base(id) { }
    }
}
