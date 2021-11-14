import { Color, Hsl, Rgb } from "../../store/Color/types";

export type ColorFormGenerator<T> = {
  color: T;
  id: string;
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
  const rgbFormGenerator: ColorFormGenerator<Rgb> = {
    id: props.color.id,
    color: props.color.rgb,
  };

  const hsvFormGenerator: ColorFormGenerator<Hsl> = {
    // Currently never being used because css doesnt accept hsv values
    id: props.color.id,
    color: props.color.hsl,
  };

  return {
    rgbFormGenerator,
    hsvFormGenerator,
  };
}
