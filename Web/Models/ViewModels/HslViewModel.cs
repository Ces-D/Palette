using Core.Domain.Interfaces;

namespace Web.Models.ViewModels
{
    public class HslViewModel : IHsl
    {
        public string Color { get; set; }

        public double Hue { get; set; }

        public double Lightness { get; set; }

        public double Saturation { get; set; }
    }
}
