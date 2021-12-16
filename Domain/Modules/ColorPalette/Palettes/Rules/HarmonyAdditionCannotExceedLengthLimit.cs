namespace Domain.Modules.ColorPalette.Palettes.Rules;

internal class HarmonyAdditionCannotExceedLengthLimit : IBusinessRule
{
    private readonly int _paletteMaxLength;
    private readonly int _harmonyLength;
    private readonly int _currentPaletteLength;
    internal HarmonyAdditionCannotExceedLengthLimit(int paletteMaxLength, int harmonyLength, int currentPaletteLength)
    {
        _paletteMaxLength = paletteMaxLength;
        _harmonyLength = harmonyLength;
        _currentPaletteLength = currentPaletteLength;
    }

    public string Message => "Adding Harmony colors will exceed the Palette max length";

    public bool IsBroken() => _paletteMaxLength < _harmonyLength + _currentPaletteLength;
}