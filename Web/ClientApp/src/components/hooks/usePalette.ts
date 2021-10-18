import { Color } from "./useColorGenerator";
import { v4 as uuidv4 } from "uuid";

export default function useColorPalette() {
  const palette = new Map<string, Color>();

  const INITIAL_COLOR = {
    id: uuidv4(),
    hex: "#000000",
    hsv: "hsv(0, 0%, 0%)",
    rgb: "rgb(0, 0, 0)F",
  };
  palette.set(INITIAL_COLOR.id, INITIAL_COLOR);

  /**
   * Updates or Adds Color object of palette
   * @param changes A copy or new Color Object
   */
  const setColor = (changes: Color) => {
    const color = palette.get(changes.id);
    if (color) {
      color.hex = changes.hex;
      color.hsv = changes.hsv;
      color.rgb = changes.rgb;
    } else {
      palette.set(changes.id, changes);
    }
  };

  const getColor = (key: string): Color => {
    const color = palette.get(key);
    return (
      color || {
        id: uuidv4(),
        hex: "#000000",
        hsv: "hsv(0, 0%, 0%)",
        rgb: "rgb(0, 0, 0)F",
      }
    );
  };

  const paletteKeys = () => {
    const keys = [...palette.keys()];
    return keys;
  };

  return { paletteKeys, getColor, setColor };
}
