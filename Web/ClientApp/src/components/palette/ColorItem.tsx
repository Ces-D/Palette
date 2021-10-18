import { useState } from "react";
import useColorGenerator, { ColorValueProps } from "../hooks/useColorGenerator";
import { ColorSelectSectionProps } from "../general/form/ColorSelectSection";
import Switch from "../general/Switch";
import HexForm from "./HexForm";
import HsvForm from "./HsvForm";
import RgbForm from "./RgbForm";
import useColorPalette from "../hooks/usePalette";

export type ColorTypes = "rgb" | "hex" | "hsv";

export type ColorFormProps = {
  color: ColorValueProps;
  value: ColorTypes;
  selectSection: ColorSelectSectionProps;
};

export default function ColorItem(props: { colorKey: string }) {
  const [colorType, setColorType] = useState<ColorTypes | string>("rgb");
  const { getColor, setColor } = useColorPalette();
  const { hex, setHex, rgb, setRgb, hsv, setHsv, color } = useColorGenerator(
    getColor(props.colorKey)
  );

  setColor(color);

  const selectSection: ColorSelectSectionProps = {
    selected: colorType,
    setColorType: setColorType,
  };

  return (
    <li className="flex-grow h-96" style={{ backgroundColor: rgb }}>
      <div className="flex flex-col justify-around items-center p-2">
        <Switch
          searchValue={colorType}
          children={[
            <RgbForm
              value="rgb"
              selectSection={selectSection}
              color={{ colorValue: rgb, setColorValue: setRgb }}
            />,
            <HexForm
              value="hex"
              selectSection={selectSection}
              color={{ colorValue: hex, setColorValue: setHex }}
            />,
            <HsvForm
              value="hsv"
              selectSection={selectSection}
              color={{ colorValue: hsv, setColorValue: setHsv }}
            />,
          ]}
        />
        <div>lock</div>
        <div>Remove</div>
      </div>
    </li>
  );
}
