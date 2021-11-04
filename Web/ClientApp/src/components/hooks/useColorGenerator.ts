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

export type ColorFormGenerator<T> = {
  color: T;
  setColor: Dispatch<SetStateAction<T>>;
  fetchModelColorValues: () => void;
};

export type UseColorGeneratorProps = {
  color: Color;
  value: ColorType | string;
};

/**
 * @summary Helper hook for generating the colors and the conversion between the various color types
 * @param {Color & ColorType} props Color values and the currently active colorType
 * @returns Three objects each containing methods and state for handling their respective Forms.
 * Design of the hook is related to the <Color>Form Component
 * Maintains many of the prop drilled entities
 */

export default function useColorGenerator(props: UseColorGeneratorProps) {
  const dispatch = useAppDispatch();
  const [rgb, setRgb] = useState<Rgb>(props.color.rgb);
  const [hsv, setHsv] = useState<Hsv>(props.color.hsv);
  const [hex, setHex] = useState<Hex>(props.color.hex);

  const hexFormGenerator: ColorFormGenerator<Hex> = {
    color: hex,
    setColor: setHex, // currently never being used
    fetchModelColorValues: () => {
      // currently never being used
      dispatch(
        fetchColorModel({
          ColorType: "hex",
          ColorValue: hex.color,
          ColorId: props.color.id,
        })
      );
    },
  };

  const rgbFormGenerator: ColorFormGenerator<Rgb> = {
    color: rgb,
    setColor: setRgb,
    fetchModelColorValues: () => {
      dispatch(
        fetchColorModel({
          ColorType: "rgb",
          ColorValue: rgb.color,
          ColorId: props.color.id,
        })
      );
    },
  };

  const hsvFormGenerator: ColorFormGenerator<Hsv> = {
    color: hsv,
    setColor: setHsv,
    fetchModelColorValues: () => {
      dispatch(
        fetchColorModel({
          ColorType: "hsv",
          ColorValue: hsv.color,
          ColorId: props.color.id,
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
