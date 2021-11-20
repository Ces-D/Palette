import { useAppDispatch } from "../../store/hooks";
import { fetchColorModel, setActiveColorType } from "../../store/Color/colorSlice";
import { BuildColorType, Color } from "../../store/Color/types";
import { useForm } from "@mantine/hooks";

/**
 * Helper hook for requesting the updated color model values from the api
 */
export default function useRequestUpdatedColorModel(
  colorModel: Color,
  currentColorType: BuildColorType
) {
  const dispatch = useAppDispatch();

  const rgbForm = useForm({
    initialValues: colorModel.rgb,
    validationRules: {
      red: (value) => value >= 0 && value < 256,
      green: (value) => value >= 0 && value < 256,
      blue: (value) => value >= 0 && value < 256,
    },
  });

  const hslForm = useForm({
    initialValues: colorModel.hsl,
    validationRules: {
      hue: (value) => value >= 0 && value < 256,
      saturation: (value) => value >= 0 && value < 256,
      lightness: (value) => value >= 0 && value < 256,
    },
  });

  /**
   * A function that couples the two dispatch functions of requesting the updated color model and updating the active color type.
   * As of now the requests are fixed to happening when the user is switching between viewing the hsl and rgb displays
   */
  const requestUpdateAndChangeColorType = () => {
    switch (currentColorType) {
      case BuildColorType.Rgb:
        dispatch(
          fetchColorModel({
            id: colorModel.id,
            colorType: BuildColorType.Rgb,
            color: formRgbColor,
          })
        );
        dispatch(
          setActiveColorType({ id: colorModel.id, colorType: BuildColorType.Hsl })
        );
        break;
      case BuildColorType.Hsl:
        dispatch(
          fetchColorModel({
            id: colorModel.id,
            colorType: BuildColorType.Hsl,
            color: formHslColor,
          })
        );
        dispatch(
          setActiveColorType({ id: colorModel.id, colorType: BuildColorType.Rgb })
        );
        break;
      default:
        break;
    }
  };

  const formHslColor = `hsl(${hslForm.values.hue}, ${hslForm.values.saturation}%, ${hslForm.values.lightness}%)`;
  const formRgbColor = `rgb(${rgbForm.values.red}, ${rgbForm.values.green}, ${rgbForm.values.blue})`;
  const isRgbActiveColorType = currentColorType === BuildColorType.Rgb;

  return {
    requestUpdateAndChangeColorType,
    isRgbActiveColorType: isRgbActiveColorType,
    formHslColor: formHslColor,
    formRgbColor: formRgbColor,
    rgbForm: rgbForm,
    hslForm: hslForm,
  };
}

// THIS FAILS FOR SOME REASON
// export interface UseFormReturnType<T> {
//   values: T;
//   errors: Record<keyof T, boolean>;
//   validate: () => boolean;
//   reset: () => void;
//   setErrors: React.Dispatch<React.SetStateAction<Record<keyof T, boolean>>>;
//   setValues: React.Dispatch<React.SetStateAction<T>>;
//   setFieldValue: <K extends keyof T, U extends T[K]>(field: K, value: U) => void;
//   setFieldError: (field: keyof T, error: boolean) => void;
//   validateField: (field: keyof T) => void;
//   resetErrors: () => void;
//   onSubmit: (handleSubmit: (values: T) => any) => (event?: React.FormEvent) => void;
// }
