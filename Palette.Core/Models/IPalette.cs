using System.Collections.Generic;

namespace Palette.Core.Models
{
    
    public interface IPalette
    {
        byte MaxLength { get; }
        ICollection<IColor> Colors { get; set; }
        string ColorHarmony { get; }
    }
}