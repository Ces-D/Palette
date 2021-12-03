using Domain.Modules.ColorPalette.Colors;
namespace Domain.Modules.ColorPalette.Harmonies;

public interface IHarmony
{
    int Length { get; }
    HarmonyType HarmonyType { get; }
    Color PrimaryColor { get; }
    List<Color> HarmonyColors();
}