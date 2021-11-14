using Core.Domain.Interfaces;

namespace Web.Models.ViewModels
{
    public record RgbViewModel : IRgb
    {
        public int Blue { get; set; }

        public string Color { get; set; }

        public int Green { get; set; }

        public int Red { get; set; }
    }
}
