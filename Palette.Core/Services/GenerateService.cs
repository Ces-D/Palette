using Palette.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.Services
{
    public class GenerateService
    {
        public IPalette Palette { get; private set; }
        public GenerateService(IPalette palette)
        {
            Palette = palette;
        }
    }
}
// Read: - https://www.colorsexplained.com/