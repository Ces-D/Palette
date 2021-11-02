import { useState } from "react";
import { v4 as uuidv4 } from "uuid";
import { Color, ColorType } from "../../store/Color/colorSlice";
import { ColorSelectSectionProps } from "../general/form/ColorSelectSection";
import Switch from "../general/Switch";
import useColorGenerator from "../hooks/useColorGenerator";
import HexForm from "./HexForm";
import HsvForm from "./HsvForm";
import RgbForm from "./RgbForm";

export type BaseColorFormProps = {
  value: ColorType;
  selectSection: ColorSelectSectionProps;
};

export default function ColorFormDisplayContainer(props: Color) {
  const [displayForm, setDisplayForm] = useState(false);
  const [colorType, setColorType] = useState<ColorType | string>("rgb");
  const { hex, setHex, rgb, setRgb, hsv, setHsv } = useColorGenerator({
    ...props,
    value: colorType,
  });

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
              key={uuidv4()}
              value="rgb"
              selectSection={selectSection}
              {...props.rgb}
              colorHandler={{ setColorValue: setRgb }}
            />,
            <HexForm
              key={uuidv4()}
              value="hex"
              selectSection={selectSection}
              {...props.hex}
              colorHandler={{ setColorValue: setHex }}
            />,
            <HsvForm
              key={uuidv4()}
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

// TODO: error with the form display. Switch find is not working
