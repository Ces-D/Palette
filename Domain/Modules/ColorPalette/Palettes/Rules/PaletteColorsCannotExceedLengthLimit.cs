namespace Domain.Modules.ColorPalette.Palettes.Rules;

internal class PaletteColorsCannotExceedLengthLimit : IBusinessRule
{
    private readonly int _colorLimit;
    private readonly int _colorLength;
    internal PaletteColorsCannotExceedLengthLimit(int colorLimit, int colorLength)
    {
        _colorLength = colorLength;
        _colorLimit = colorLimit;
    }
    public string Message => "Palette Colors cannot exceed the length limit";

    public bool IsBroken() => _colorLength + 1 > _colorLimit;
}
