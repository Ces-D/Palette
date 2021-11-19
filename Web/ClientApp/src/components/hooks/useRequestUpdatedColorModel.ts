import { useAppDispatch } from "../../store/hooks";
import { fetchColorModel, setActiveColorType } from "../../store/Color/colorSlice";
import { BuildColorType, Color } from "../../store/Color/types";
import { useForm } from "@mantine/hooks";

/**
 * @abstract Helper hook for requesting the updated color model values from the api
 * @param id The id of the color
 * @param currentColorType
 * @returns
 */
export default function useRequestUpdatedColorModel(
  colorModel: Color,
  currentColorType: BuildColorType
) {
  const dispatch = useAppDispatch();

  /**
   * A function that couples the dispatches of requesting the updated color model and updating the active color type.
   * As of now the requests are fixed to happening when the user is switching between viewing the hsl and rgb displays
   * @param activeForm The form for the active colorType. The forms can only be those exported from this hook
   */
  const requestUpdateAndChangeColorType = (activeForm: any) => {
    switch (currentColorType) {
      case BuildColorType.Rgb:
        dispatch(
          fetchColorModel({
            Id: colorModel.id,
            ColorType: BuildColorType.Rgb,
            Color: activeForm,
          })
        );
        dispatch(
          setActiveColorType({ id: colorModel.id, colorType: BuildColorType.Hsl })
        );
        break;
      case BuildColorType.Hsl:
        dispatch(
          fetchColorModel({
            Id: colorModel.id,
            ColorType: BuildColorType.Hsl,
            Color: activeForm,
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

  /**
   * Boolean for checking if the active colorType is set to RGB
   */
  const isRgbActiveColorType = currentColorType === BuildColorType.Rgb;

  /**
   * Form for building a new Rgb Color Model. This is used to allow any rendering components to stay uncontrolled
   */
  const rgbForm = useForm({
    initialValues: colorModel.rgb,
    validationRules: {
      red: (value) => value >= 0 && value < 256,
      green: (value) => value >= 0 && value < 256,
      blue: (value) => value >= 0 && value < 256,
    },
  });

  /**
   * Form for building a new Hsl Color Model. This is used to allow any rendering components to stay uncontrolled
   */
  const hslForm = useForm({
    initialValues: colorModel.hsl,
    validationRules: {
      hue: (value) => value >= 0 && value < 256,
      saturation: (value) => value >= 0 && value < 256,
      lightness: (value) => value >= 0 && value < 256,
    },
  });

  return {
    requestUpdateAndChangeColorType,
    isRgbActiveColorType: isRgbActiveColorType,
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
