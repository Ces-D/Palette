import { Dispatch, SetStateAction, useState } from "react";
import {
  Color,
  ColorType,
  Hex,
  Hsv,
  Rgb,
  fetchColorModel,
} from "../../store/Color/colorSlice";
import { useAppDispatch } from "../../store/hooks";

export type ColorForm<T> = {
  color: T;
  setColor: Dispatch<SetStateAction<T>>;
  fetchModelColorValues: () => void;
};

type Props = Color & {
  value: ColorType | string;
};

/**
 * @summary Helper hook for generating the colors and the conversion between the various color types
 * @param {Color & ColorType} paletteColor Color values and the currently active colorType
 * @returns Three objects each containing methods and state for handling their respective Forms.
 * Design of the hook is related to the <Color>Form Component 
 */

export default function useColorGenerator(paletteColor: Props) {
  const dispatch = useAppDispatch();
  const [rgb, setRgb] = useState<Rgb>(paletteColor.rgb);
  const [hsv, setHsv] = useState<Hsv>(paletteColor.hsv);
  const [hex, setHex] = useState<Hex>(paletteColor.hex);

  const hexFormGenerator: ColorForm<Hex> = {
    color: hex,
    setColor: setHex,
    fetchModelColorValues: () => {
      dispatch(
        fetchColorModel({
          ColorType: "hex",
          ColorValue: hex.color,
          ColorId: paletteColor.id,
        })
      );
    },
  };

  const rgbFormGenerator: ColorForm<Rgb> = {
    color: rgb,
    setColor: setRgb,
    fetchModelColorValues: () => {
      dispatch(
        fetchColorModel({
          ColorType: "rgb",
          ColorValue: rgb.color,
          ColorId: paletteColor.id,
        })
      );
    },
  };

  const hsvFormGenerator: ColorForm<Hsv> = {
    color: hsv,
    setColor: setHsv,
    fetchModelColorValues: () => {
      dispatch(
        fetchColorModel({
          ColorType: "hsv",
          ColorValue: hsv.color,
          ColorId: paletteColor.id,
        })
      );
    },
  };

  return {
    hexFormGenerator,
    rgbFormGenerator,
    hsvFormGenerator,
  };
}
