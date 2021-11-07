import { useState } from "react";
import { v4 as uuidv4 } from "uuid";
import { ColorState, ColorType } from "../../store/Color/types";
import Switch from "../general/Switch";
import useColorGenerator from "../hooks/useColorGenerator";
import HsvForm from "./HsvForm";
import RgbForm from "./RgbForm";
import { useAppDispatch } from "../../store/hooks";
import { setIsFormDisplayed } from "../../store/Color/colorSlice";
import { ColorSelectSectionProps } from "../general/form/ColorSelectSection";
/**
 * @summary Each Color Form should implement these Props and extend on them with their respective FormProps<ColorType>
 */
export type BaseColorFormProps = {
  value: ColorType;
  baseSelectSection: ColorSelectSectionProps;
};

export default function ColorFormDisplayContainer(props: ColorState) {
  const dispatch = useAppDispatch();
  const [colorType, setColorType] = useState<ColorType | string>("rgb");
  const { rgbFormGenerator, hsvFormGenerator } = useColorGenerator({
    color: props.color,
  });

  const selectSection: ColorSelectSectionProps = {
    selected: colorType,
    setActiveColorType: setColorType,
    rgbColor: rgbFormGenerator.color,
  };

  return (
    <>
      {props.isFormDisplayed && (
        <Switch
          searchValue={colorType}
          children={[
            <RgbForm
              key={uuidv4()}
              value="rgb"
              baseSelectSection={selectSection}
              {...rgbFormGenerator}
            />,
            <HsvForm
              key={uuidv4()}
              value="hsv"
              baseSelectSection={selectSection}
              {...hsvFormGenerator}
            />,
          ]}
        />
      )}
      <button
        className="w-full text-center"
        onClick={() => dispatch(setIsFormDisplayed({ id: props.color.id }))}
      >
        <h2 className="text-2xl">
          {(colorType === "rgb" &&
            `rgb(${rgbFormGenerator.color.red}, ${rgbFormGenerator.color.green}, ${rgbFormGenerator.color.blue})`) ||
            (colorType === "hsv" &&
              `hsv(${hsvFormGenerator.color.hue}, ${hsvFormGenerator.color.saturation}%, ${hsvFormGenerator.color.hValue}%)`)}
        </h2>
      </button>
    </>
  );
}
