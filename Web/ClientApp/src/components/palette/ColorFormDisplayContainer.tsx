import { Dispatch, SetStateAction, useState } from "react";
import { v4 as uuidv4 } from "uuid";
import { ColorState, ColorType } from "../../store/Color/types";
import Switch from "../general/Switch";
import useColorGenerator from "../hooks/useColorGenerator";
import HsvForm from "./HsvForm";
import RgbForm from "./RgbForm";
import { useAppDispatch } from "../../store/hooks";
import { setIsFormDisplayed } from "../../store/Color/colorSlice";
/**
 * @summary Each Color Form should implement these Props and extend on them with their respective FormProps<ColorType>
 */
export type BaseColorFormProps = {
  value: ColorType;
  baseSelectSection: BaseSelectSection;
};

/**
 * @summary Each Color Form should implement the same BaseSelectSection
 */
type BaseSelectSection = {
  activeColorType: ColorType | string;
  setActiveColorType: Dispatch<SetStateAction<ColorType | string>>;
  hexValue: string;
};

export default function ColorFormDisplayContainer(props: ColorState) {
  const dispatch = useAppDispatch();
  const [colorType, setColorType] = useState<ColorType | string>("rgb");
  const { rgbFormGenerator, hsvFormGenerator, hexFormGenerator } = useColorGenerator({
    color: props.color,
  });

  const selectSection: BaseSelectSection = {
    activeColorType: colorType,
    setActiveColorType: setColorType,
    hexValue: hexFormGenerator.color.color,
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
          {(colorType === "rgb" && rgbFormGenerator.color.color) ||
            (colorType === "hsv" && hsvFormGenerator.color.color)}
        </h2>
      </button>
    </>
  );
}
