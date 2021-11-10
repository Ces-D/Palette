using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Interfaces;

namespace Core.Application.Entities
{
    public record ComplimentaryHarmony
    {
        public ColorEntity Primary { get; set; }
        public ColorEntity Compliment { get; set; }
    }
}
