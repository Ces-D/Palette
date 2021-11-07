using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.ValueObjects;

namespace Core.Domain.Entities
{
    public class Color
    {
        public string Id { get; set; }
        public Rgb Rgb { get; set; }
        public Hsv Hsv { get; set; }
        public Hex Hex { get; set; }
    }
}
