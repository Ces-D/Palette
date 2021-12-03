using Domain.Modules.ColorPalette.Colors;
namespace Domain.Modules.ColorPalette.Harmonies;

public class Harmony : Entity
{
    public HarmonyId Id { get; private set; }
    private Color _primaryColor;
    internal HarmonyType HarmonyType { get; private set; }
    public IHarmony HarmonyData { get; private set; }

    internal Harmony(Color primaryColor, HarmonyType harmonyType)
    {
        Id = new HarmonyId(Guid.NewGuid());
        _primaryColor = primaryColor;
        HarmonyType = harmonyType;

        switch (harmonyType)
        {
            case (HarmonyType.Complimentary):
                HarmonyData = ComplimentaryHarmony.CreateNew(primaryColor);
                break;
            default:
                HarmonyData = ComplimentaryHarmony.CreateNew(primaryColor);
                break;
        }
    }

}

// TODO: consider making this an abstract class and an interface so that the same logic is managed through contracts
// and it will be specialized for each kind of harmony.