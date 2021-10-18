import { useState, SetStateAction, Dispatch } from "react";

export type ColorValueProps = {
  colorValue: string;
  setColorValue: Dispatch<SetStateAction<string>>;
};

export type Color = {
  id: string;
  rgb: string;
  hex: string;
  hsv: string;
};

export default function useColorGenerator(paletteColor: Color) {
  const [rgb, setRgb] = useState<string>(paletteColor.rgb);
  const [hsv, setHsv] = useState<string>(paletteColor.hsv);
  const [hex, setHex] = useState<string>(paletteColor.hex);

  const color: Color = {
    id: paletteColor.id,
    rgb: rgb,
    hsv: hsv,
    hex: hex,
  };

  //TODO: add useMemo to conversion between colorTypes

  return { hex, setHex, rgb, setRgb, hsv, setHsv, color };
}
