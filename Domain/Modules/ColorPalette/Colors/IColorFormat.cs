namespace Domain.Modules.ColorPalette.Colors;

public interface IColorFormat
{
    ColorType ColorType { get; }
    IColorFormat ConvertTo(ColorType formatType);
}