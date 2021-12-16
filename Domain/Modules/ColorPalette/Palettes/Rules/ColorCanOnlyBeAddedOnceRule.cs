using Domain.Modules.ColorPalette.Colors;
namespace Domain.Modules.ColorPalette.Palettes.Rules;

internal class ColorCanOnlyBeAddedOnceRule : IBusinessRule
{
    private readonly List<Color> _colors;
    private readonly ColorId _colorId;
    internal ColorCanOnlyBeAddedOnceRule(List<Color> colors, ColorId colorId)
    {
        _colors = colors;
        _colorId = colorId;
    }
    public string Message => "Color can only be added to a Palette once";

    public bool IsBroken()
    {
        var onlyOne = _colors.SingleOrDefault(c => c.IsActiveInPalette(_colorId));
        return onlyOne == null;
    }
}