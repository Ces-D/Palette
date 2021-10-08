using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.Interfaces
{
    public interface IColor<T>
    {
        public string Color { get; init; }
        public T A { get; init; }
        public T B { get; init; }
        public T C { get; init; }
    }
}
