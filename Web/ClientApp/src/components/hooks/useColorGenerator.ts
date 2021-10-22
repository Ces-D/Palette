import { useState, SetStateAction, Dispatch, useEffect, useContext } from "react";
import { PaletteContext } from "../contexts/ColorPalette/PaletteContext";
import { Color, Hex, Hsv, Rgb } from "../contexts/ColorPalette/types";

export type ColorValueProps<T> = {
  setColorValue: Dispatch<SetStateAction<T>>; 
}; 

export default function useColorGenerator(paletteColor: Color) {
  const { dispatch } = useContext(PaletteContext);
  const [rgb, setRgb] = useState<Rgb>(paletteColor.rgb);
  const [hsv, setHsv] = useState<Hsv>(paletteColor.hsv);
  const [hex, setHex] = useState<Hex>(paletteColor.hex);

  const color: Color = {
    id: paletteColor.id,
    rgb: rgb,
    hsv: hsv,
    hex: hex,
  };

  useEffect(() => {
    dispatch({ type: "update-color", payload: { color: color, colorId: color.id } });
  }, [hex, rgb, hsv]);

  return { hex, setHex, rgb, setRgb, hsv, setHsv };
}
