namespace Palette.Core.Models
{
    public interface IColor
    {
        string Role { get; set; }
        bool Locked { get; set; }
        string Value { get; set; }
    }
}