import { useState, SetStateAction, Dispatch, useEffect } from "react";
import {
  Color,
  ColorType,
  Hex,
  Hsv,
  Rgb,
  pushColorModel,
} from "../../store/Color/colorSlice";
import { useAppDispatch } from "../../store/hooks";
import { setColorError } from "../../store/Palette/paletteSlice";

export type ColorValueProps<T> = {
  setColorValue: Dispatch<SetStateAction<T>>;
};

type Props = Color & {
  value: ColorType;
};

export default function useColorGenerator(paletteColor: Props) {
  const dispatch = useAppDispatch();
  const [rgb, setRgb] = useState<Rgb>(paletteColor.rgb);
  const [hsv, setHsv] = useState<Hsv>(paletteColor.hsv);
  const [hex, setHex] = useState<Hex>(paletteColor.hex);

  useEffect(() => {
    switch (paletteColor.value) {
      case "rgb":
        dispatch(
          pushColorModel({
            ColorType: paletteColor.value,
            ColorValue: paletteColor.rgb.color,
            ColorId: paletteColor.id,
          })
        );
        break;
      case "hex":
        dispatch(
          pushColorModel({
            ColorType: paletteColor.value,
            ColorValue: paletteColor.hex.color,
            ColorId: paletteColor.id,
          })
        );
        break;
      case "hsv":
        dispatch(
          pushColorModel({
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
