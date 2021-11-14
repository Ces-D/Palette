namespace Core.Domain.Interfaces
{
    public interface IHsl
    {
        string Color { get; }
        double Hue { get; }
        double Lightness { get; }
        double Saturation { get; }
    }
}