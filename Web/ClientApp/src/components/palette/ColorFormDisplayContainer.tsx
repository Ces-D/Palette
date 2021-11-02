import { Dispatch, SetStateAction, useState } from "react";
import { v4 as uuidv4 } from "uuid";
import { Color, ColorType } from "../../store/Color/colorSlice";
import Switch from "../general/Switch";
import useColorGenerator from "../hooks/useColorGenerator";
// import HexForm from "./HexForm";
import HsvForm from "./HsvForm";
import RgbForm from "./RgbForm";

export type BaseColorFormProps = {
  value: ColorType;
  baseSelectSection: BaseSelectSection;
};
type BaseSelectSection = {
  activeColorType: ColorType | string;
  setActiveColorType: Dispatch<SetStateAction<ColorType | string>>;
};

export default function ColorFormDisplayContainer(props: Color) {
  const [displayForm, setDisplayForm] = useState(false);
  const [colorType, setColorType] = useState<ColorType | string>("rgb");
  const { rgbFormGenerator, hsvFormGenerator } = useColorGenerator({
    ...props,
    value: colorType,
  });

  const selectSection: BaseSelectSection = {
    activeColorType: colorType,
    setActiveColorType: setColorType,
  };

  return (
    <>
      {displayForm && (
        <Switch
          searchValue={colorType}
          children={[
            <RgbForm
              key={uuidv4()}
              value="rgb"
              baseSelectSection={selectSection}
              {...rgbFormGenerator}
            />,
            // <HexForm
            //   key={uuidv4()}
            //   value="hex"
            //   baseSelectSection={selectSection}
            //   {...hexFormGenerator}
            // />,
            <HsvForm
              key={uuidv4()}
              value="hsv"
              baseSelectSection={selectSection}
              {...hsvFormGenerator}
            />,
          ]}
        />
      )}
      <button className="w-full text-center" onClick={() => setDisplayForm(!displayForm)}>
        <h2 className="text-2xl">
          {(colorType === "rgb" && rgbFormGenerator.color.color) ||
            (colorType === "hsv" && hsvFormGenerator.color.color)}
        </h2>
      </button>
    </>
  );
}

// TODO: error with the form display. Switch find is not working
