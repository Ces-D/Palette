using Domain.Modules.ColorPalette.Colors;
namespace Domain.Modules.ColorPalette.Harmonies;

public record ComplimentaryHarmony : ValueObject, IHarmony
{
    public int Length { get; }
    public HarmonyType HarmonyType { get; }
    public Color PrimaryColor { get; }
    private List<Color> _complimentaryColors;
    private ComplimentaryHarmony(Color primaryColor)
    {
        PrimaryColor = primaryColor;
        Length = 2;
        HarmonyType = HarmonyType.Complimentary;
        _complimentaryColors = new List<Color>() { primaryColor };
    }

    private void GenerateColors()
    {
// TODO: create compmliments
    }
    public static ComplimentaryHarmony CreateNew(Color primaryColor)
    {
        return new ComplimentaryHarmony(primaryColor);
    }

    public List<Color> HarmonyColors()
    {
        this.GenerateColors();
        return _complimentaryColors;
    }
}