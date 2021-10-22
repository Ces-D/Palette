import { useState } from "react";
import { Color } from "../contexts/ColorPalette/types";
import { ColorSelectSectionProps } from "../general/form/ColorSelectSection";
import Switch from "../general/Switch";
import useColorGenerator from "../hooks/useColorGenerator";
import HexForm from "./HexForm";
import HsvForm from "./HsvForm";
import RgbForm from "./RgbForm";

export type ColorTypes = "rgb" | "hex" | "hsv";
export type BaseColorFormProps = {
  value: ColorTypes;
  selectSection: ColorSelectSectionProps;
};

export default function ColorFormDisplayContainer(props: Color) {
  const [displayForm, setDisplayForm] = useState(false);
  const [colorType, setColorType] = useState<ColorTypes | string>("rgb");
  const { hex, setHex, rgb, setRgb, hsv, setHsv } = useColorGenerator(props);

  const selectSection: ColorSelectSectionProps = {
    selected: colorType,
    setColorType: setColorType,
  };

  return (
    <>
      {displayForm && (
        <Switch
          searchValue={colorType}
          children={[
            <RgbForm
              value="rgb"
              selectSection={selectSection}
              {...props.rgb}
              colorHandler={{ setColorValue: setRgb }}
            />,
            <HexForm
              value="hex"
              selectSection={selectSection}
              {...props.hex}
              colorHandler={{ setColorValue: setHex }}
            />,
            <HsvForm
              value="hsv"
              selectSection={selectSection}
              {...props.hsv}
              colorHandler={{ setColorValue: setHsv }}
            />,
          ]}
        />
      )}
      <button className="w-full text-center" onClick={() => setDisplayForm(!displayForm)}>
        <h2 className="text-2xl">
          {(colorType === "rgb" && rgb.color) ||
            (colorType === "hex" && hex.color) ||
            (colorType === "hsv" && hsv.color)}
        </h2>
      </button>
    </>
  );
}

// TODO: style for mobile and other styling to make pretty
// TODO: could add a change color reducer action that calls api and sets other color values
