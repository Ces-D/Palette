using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Interfaces;

namespace Core.Application.Entities
{
    public record ColorEntity : IColor
    {
        public string Id { get; set; }
        public IRgb Rgb { get; set; }
        public IHsv Hsv { get; set; }
        public IHex Hex { get; set; }
        public IHsl Hsl { get; set; }
    }
}
