using Domain.Modules.ColorPalette.Colors;
using Domain.Modules.ColorPalette.Authors;
using Domain.Modules.ColorPalette.SharedKernel;
using Domain.Modules.ColorPalette.Palettes.Rules;
using Domain.Modules.ColorPalette.Harmonies;

namespace Domain.Modules.ColorPalette.Palettes;
public class Palette : Entity
{
    public PaletteId Id { get; private set; }
    private string _title;
    private AuthorId _authorId;
    private List<Color> _colorPalette;
    private DateTime _createDate;
    private Harmony? _activeHarmony;
    private const int PALETTE_MAX_LENGTH = 10;

    private Palette(string title, AuthorId authorId)
    {
        Id = new PaletteId(Guid.NewGuid());
        _title = title;
        _authorId = authorId;
        _colorPalette = new List<Color>();
        _createDate = SystemClock.Now;
    }

    internal static Palette CreateNew(string name, AuthorId authorId)
    {
        return new Palette(name, authorId);
    }

    public void AddColor(Color color)
    {
        this.CheckRule(new PaletteColorsCannotExceedLengthLimit(PALETTE_MAX_LENGTH, _colorPalette.Count));
        this.CheckRule(new ColorCanOnlyBeAddedOnceRule(_colorPalette, color.Id));
        _colorPalette.Add(color);

        // TODO; send event 
    }

    public void AddHarmony(Color primaryColor, HarmonyType harmonyType)
    {
        var harmony = new Harmony(primaryColor, harmonyType);
        this.CheckRule(new HarmonyAdditionCannotExceedLengthLimit(PALETTE_MAX_LENGTH, harmony.HarmonyData.Length, _colorPalette.Count));

        _activeHarmony = harmony;
        //TODO: move this into the harmony function because this handles its own state and updating is not possible likethis
        // this should trigger the creation of new harmony colors
    }
}