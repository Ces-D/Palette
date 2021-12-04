using Domain.Modules.ColorPalette.Colors;
namespace Domain.Modules.ColorPalette.Harmonies;

public class Harmony : Entity
{
    public HarmonyId Id { get; private set; }
    private Color _primaryColor;
    private HarmonyType _harmonyType;
    private IHarmony _harmonyData;

    internal Harmony(Color primaryColor, HarmonyType harmonyType)
    {
        Id = new HarmonyId(Guid.NewGuid());
        _primaryColor = primaryColor;
        _harmonyType = harmonyType;
        _harmonyData = this.NewHarmonyData(harmonyType);
    }

    private IHarmony NewHarmonyData(HarmonyType harmonyType)
    {
        IHarmony harmonyData;

        switch (harmonyType)
        {
            case (HarmonyType.Complimentary):
                harmonyData = ComplimentaryHarmony.CreateNew(_primaryColor);
                break;
            default:
                harmonyData = ComplimentaryHarmony.CreateNew(_primaryColor);
                break;
        }

        return harmonyData;
    }

    internal void ChangeHarmonyType(HarmonyType newType)
    {
        _harmonyType = newType;
        _harmonyData = this.NewHarmonyData(newType);
    }

    internal void ChangePrimaryColor(Color newColor)
    {
        _primaryColor = newColor;
        this.NewHarmonyData(_harmonyType);
    }
}
