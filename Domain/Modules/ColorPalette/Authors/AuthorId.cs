namespace Domain.Modules.ColorPalette.Authors;

public record AuthorId : TypedIdValueBase
{
    public AuthorId(Guid id) : base(id) { }
}