using Domain.Modules.ColorPalette.Colors.Rules;

namespace Domain.Modules.ColorPalette.Colors;
public class Color : Entity
{
    public ColorId Id { get; private set; }
    private ColorType _colorType;
    private IColorFormat _color;

    private Color(ColorType colorType, IColorFormat color)
    {
        this.CheckRule(new ColorTypeAndColorRepresentTheSameColorFormatRule(colorType, color));

        Id = new ColorId(Guid.NewGuid());
        _colorType = colorType;
        _color = color;
        // TODO: figure out where AddDomainEvents fit in - https://github.com/kgrzybek/modular-monolith-with-ddd/blob/master/src/Modules/Meetings/Domain/MeetingGroupProposals/MeetingGroupProposal.cs
    }

    public static Color CreateNew(ColorType colorType, IColorFormat color)
    {
        return new Color(colorType, color);
    }

    internal IColorFormat ColorValue => _color;

    internal void ChangeColorType(ColorType newType)
    {
        _colorType = newType;
        _color.ConvertTo(newType);
    }

    internal void ChangeColorValues(IColorFormat newValues)
    {
        this.CheckRule(new ColorTypeAndColorRepresentTheSameColorFormatRule(_colorType, newValues));
        _color = newValues;
    }

    internal bool IsActiveInPalette(ColorId colorId)
    {
        return colorId == Id;
    }

    internal bool IsHarmonyPrimaryColor(ColorId colorId)
    {
        return colorId == Id;
    }
}