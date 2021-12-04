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

    public void AddNewColor(Color color)
    {
        this.CheckRule(new PaletteColorsCannotExceedLengthLimit(PALETTE_MAX_LENGTH, _colorPalette.Count));
        this.CheckRule(new ColorCanOnlyBeAddedOnceRule(_colorPalette, color.Id));
        _colorPalette.Add(color);

        // TODO; send event 
    }

    public void UpdateExistingColor(ColorId targetColor, IColorFormat colorFormat){
        // _colorPalette.Single(c=> c.UpdateColorValues())
        // TODO: When the TODO in the Color.cs is complete come back here
    }
}