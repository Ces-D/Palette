using Core.Domain.Interfaces;
using Core.Application.Entities;
using System;

namespace Web.Models.ViewModels
{
    public record ColorViewModel : IColor
    {
        public string Id { get; set; }
        public RgbViewModel Rgb { get; set; }
        public HslViewModel Hsl { get; set; }

        public static explicit operator ColorViewModel(ColorEntity colorEntity)
        {
            RgbViewModel rgbViewModel = new()
            {
                Color = colorEntity.Rgb.Color,
                Red = colorEntity.Rgb.Red,
                Blue = colorEntity.Rgb.Blue,
                Green = colorEntity.Rgb.Green
            };

            HslViewModel hslViewModel = new()
            {
                Color = colorEntity.Hsl.Color,
                Hue = colorEntity.Hsl.Hue,
                Saturation = colorEntity.Hsl.Saturation,
                Lightness = colorEntity.Hsl.Lightness
            };

            return new ColorViewModel() { Id = colorEntity.Id, Rgb = rgbViewModel, Hsl = hslViewModel };
        }

    }
}
