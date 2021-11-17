import { updateLocaleRgbValueOfColorModel } from "../../store/Color/colorSlice";
import { Color, Hsl, Rgb } from "../../store/Color/types";
import { useAppDispatch } from "../../store/hooks";

export type ColorFormGenerator<T> = {
  color: T;
  dispatchColorInputHandler?: (value: any, key: any) => void;
};

export type UseColorGeneratorProps = {
  color: Color;
};

/**
 * @summary Helper hook for generating the colors and the conversion between the various color types
 * @param {UseColorGeneratorProps} props Color values
 * @returns Two objects each containing methods and state for handling their respective Forms.
 * Design of the hook is related to the <Color>Form Component
 * Maintains many of the prop drilled entities
 */

export default function useColorGenerator(props: UseColorGeneratorProps) {
  const dispatch = useAppDispatch();
  const rgbFormGenerator: ColorFormGenerator<Rgb> = {
    color: props.color.rgb,
    dispatchColorInputHandler: (value: number, key: "r" | "g" | "b") => {
      dispatch(
        updateLocaleRgbValueOfColorModel({
          id: props.color.id,
          colorValue: value,
          rgbType: key,
        })
      );
    },
  };

  const hsvFormGenerator: ColorFormGenerator<Hsl> = {
    color: props.color.hsl,
  };

  return {
    rgbFormGenerator,
    hsvFormGenerator,
  };
}
