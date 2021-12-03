namespace Domain.Modules.ColorPalette.Colors.Rules;

internal class ColorTypeAndColorRepresentTheSameColorFormatRule : IBusinessRule
{
    private readonly bool _formatsMatch;
    public ColorTypeAndColorRepresentTheSameColorFormatRule(ColorType colorType, IColorFormat color)
    {
        _formatsMatch = colorType.Equals(color.ColorType);
    }
    public string Message => "Color Type and Color implementation must represent the same color format";
    public bool IsBroken() => this._formatsMatch;
}