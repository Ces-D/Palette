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

    public static ComplimentaryHarmony CreateNew(Color primaryColor)
    {
        return new ComplimentaryHarmony(primaryColor);
    }

    public List<Color> HarmonyColors()
    {
        this.GenerateCompliment();
        return _complimentaryColors;
    }

    private void GenerateCompliment()
    {
        Hsl primaryHsl, complimentHsl;

        // Get the Hsl from the primary color regardless of IColorFormat
        primaryHsl = PrimaryColor.ColorFormat.ColorType != ColorType.Hsl ?
            (Hsl)PrimaryColor.ColorFormat.ConvertTo(ColorType.Hsl) : (Hsl)PrimaryColor.ColorFormat;

        // Populate the complimentHsl value
        if (primaryHsl.Hue == 0 && primaryHsl.Saturation == 0 && primaryHsl.Lightness == 0) // compliment of black is white
        {
            complimentHsl = Hsl.Create("hsl(0, 0%, 100%)");
        }
        else if (primaryHsl.Hue == 0 && primaryHsl.Saturation == 0 && primaryHsl.Lightness == 100) // compliment of white is black
        {
            complimentHsl = Hsl.Create("hsl(0, 0%, 0%)");
        }
        else
        {
            var complimentHue = primaryHsl.Hue - 180;
            if (complimentHue < 0)
            {
                complimentHue = 360 - complimentHue;
            }
            complimentHsl = Hsl.Create($"hsv({complimentHue}, {primaryHsl.Saturation}%, {primaryHsl.Lightness}%");
        }

        // create the compliment color using the complimentHsl 
        var complimentColor = Color.CreateNew(ColorType.Hsl, complimentHsl);
        // Add the new compliment
        _complimentaryColors.Add(complimentColor);
    }
}