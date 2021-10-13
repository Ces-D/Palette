using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure.Models.Colors
{
    public interface IColorFormat<T>
    {
        public string Color { get; init; }
        public T A { get; init; }
        public T B { get; init; }
        public T C { get; init; }
    }
}
