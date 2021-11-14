namespace Core.Domain.Interfaces
{
    public interface IHsv
    {
        string Color { get; }
        double Hue { get; }
        double Saturation { get; }
        double Value { get; }
    }
}