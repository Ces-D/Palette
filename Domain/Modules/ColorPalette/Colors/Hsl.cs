using System.Text.RegularExpressions;
namespace Domain.Modules.ColorPalette.Colors;

public record Hsl : ValueObject, IColorFormat
{
    public int Hue { get; }
    public int Saturation { get; }
    public int Lightness { get; }
    public ColorType ColorType { get; }

    private Hsl(int hue, int saturation, int lightness)
    {
        Hue = hue;
        Saturation = saturation;
        Lightness = lightness;
        ColorType = ColorType.Hsl;
    }

    public static Hsl Create(string hslColor)
    {
        var hslFormatPattern = new Regex(@"hsl\((\d{1,3}), (\d{1,3})%, (\d{1,3})%\)");
        if (hslFormatPattern.IsMatch(hslColor))
        {
            string hslNonDigitPattern = @"\D+";
            var digits = Regex.Split(hslColor, hslNonDigitPattern);
            var hue = int.Parse(digits[1]);
            var saturation = int.Parse(digits[2]);
            var lightness = int.Parse(digits[3]);

            if (hue < 0 || hue > 360) { throw new ArgumentOutOfRangeException("Hue", "Hue should be between 0 and 360"); }
            if (saturation < 0 || saturation > 100) { throw new ArgumentOutOfRangeException("Saturation", "Saturation should be between 0 and 100"); }
            if (lightness < 0 || lightness > 100) { throw new ArgumentOutOfRangeException("Lightness", "Lightness should be between 0 and 100"); }

            return new Hsl(hue, saturation, lightness);
        }
        else { throw new ArgumentException("Invalid hsl string", nameof(hslColor)); }
    }

    public IColorFormat ConvertTo(ColorType toType)
    {
        switch (toType)
        {
            case ColorType.Rgb:
                return this.ToRgb();
            default:
                return this;
        }
    }

    private Rgb ToRgb()
    {
        var L = (double)Lightness / 100;
        var S = (double)Saturation / 100;
        var d = S * (1 - Math.Abs(2 * L - 1));
        var m = 255 * (L - d / 2);

        var x = d * (1 - Math.Abs((Hue / 60) % 2 - 1));

        double R = 0;
        double G = 0;
        double B = 0;

        if (0 <= Hue && Hue < 60)
        {
            R = 255 * d + m;
            G = 255 * x + m;
            B = m;
        }
        else if (60 <= Hue && Hue < 120)
        {
            R = 255 * x + m;
            G = 255 * d + m;
            B = m;
        }
        else if (120 <= Hue && Hue < 180)
        {
            R = m;
            G = 255 * d + m;
            B = 255 * x + m;
        }
        else if (180 <= Hue && Hue < 240)
        {
            R = m;
            G = 255 * x + m;
            B = 255 * d + m;
        }
        else if (240 <= Hue && Hue < 300)
        {
            R = 255 * x + m;
            G = m;
            B = 255 * d + m;
        }
        else if (300 <= Hue && Hue < 360)
        {
            R = 255 * d + m;
            G = m;
            B = 255 * x + m;
        }

        return Rgb.Create($"rgb({Math.Round(R)}, {Math.Round(G)}, {Math.Round(B)})");
    }
}