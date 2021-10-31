import { useState, SetStateAction, Dispatch, useEffect } from "react";
import {
  Color,
  ColorType,
  Hex,
  Hsv,
  Rgb,
  fetchColorModel,
} from "../../store/Color/colorSlice";
import { useAppDispatch } from "../../store/hooks";
import { setColorError } from "../../store/Palette/paletteSlice";

export type ColorValueProps<T> = {
  setColorValue: Dispatch<SetStateAction<T>>;
};

type Props = Color & {
  value: ColorType | string;
};

/**
 * @summary Helper hook for generating the colors and the conversion between the various color types
 * whenever changes are made.
 * @param {Color} paletteColor
 * @returns
 */

export default function useColorGenerator(paletteColor: Props) {
  const dispatch = useAppDispatch();
  const [rgb, setRgb] = useState<Rgb>(paletteColor.rgb);
  const [hsv, setHsv] = useState<Hsv>(paletteColor.hsv);
  const [hex, setHex] = useState<Hex>(paletteColor.hex);

  useEffect(() => {
    switch (paletteColor.value) {
      case "rgb":
        dispatch(
          fetchColorModel({
            ColorType: paletteColor.value,
            ColorValue: paletteColor.rgb.color,
            ColorId: paletteColor.id,
          })
        );
        break;
      case "hex":
        dispatch(
          fetchColorModel({
            ColorType: paletteColor.value,
            ColorValue: paletteColor.hex.color,
            ColorId: paletteColor.id,
          })
        );
        break;
      case "hsv":
        dispatch(
          fetchColorModel({
            ColorType: paletteColor.value,
            ColorValue: paletteColor.hsv.color,
            ColorId: paletteColor.id,
          })
        );
        break;
      default:
        dispatch(
          setColorError({ errorMsg: `Error generating your ${paletteColor.value} color` })
        );
        break;
    }
  }, [rgb, hsv, hex]);

  return { hex, setHex, rgb, setRgb, hsv, setHsv };
}
