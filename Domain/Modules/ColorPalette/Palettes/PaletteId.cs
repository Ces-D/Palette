namespace Domain.Modules.ColorPalette.Palettes;

public record PaletteId : TypedIdValueBase
{
    public PaletteId(Guid id) : base(id) { }
}