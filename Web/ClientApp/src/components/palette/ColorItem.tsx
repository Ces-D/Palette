import { useState } from "react";
import useColorGenerator, { ColorValueProps } from "../hooks/useColorGenerator";
import { ColorSelectSectionProps } from "../general/form/ColorSelectSection";
import Switch from "../general/Switch";
import HexForm from "./HexForm";
import HsvForm from "./HsvForm";
import RgbForm from "./RgbForm";
import useColorPalette from "../hooks/usePalette";
import LockOpenClosed from "../general/icons/LockOpenIcon";
import LockClosedIcon from "../general/icons/LockClosedIcon";
import PlusIcon from "../general/icons/PlusIcon";
import MinusIcon from "../general/icons/MinusIcon";

export type ColorTypes = "rgb" | "hex" | "hsv";

export type ColorFormProps = {
  color: ColorValueProps;
  value: ColorTypes;
  selectSection: ColorSelectSectionProps;
};

export default function ColorItem(props: { colorKey: string }) {
  const [lock, setLocked] = useState(false);
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
    <li className="flex-grow h-96 relative" style={{ backgroundColor: rgb }}>
      <div className="flex flex-col justify-around items-center p-2 h-full">
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
        <button
          className="rounded-full hover:bg-gray-50 p-2"
          onClick={() => setLocked(!lock)}
        >
          {!lock ? (
            <LockOpenClosed class="fill-current text-red-600 h-5 w-5" />
          ) : (
            <LockClosedIcon class="fill-current text-red-600 h-5 w-5" />
          )}
        </button>
        <button className="absolute top-1/2 right-5 rounded-full hover:bg-gray-50 p-2">
          <PlusIcon class="fill-current text-red-600 h-5 w-5" />
        </button>
        <button className="absolute top-1/2 left-5 rounded-full hover:bg-gray-50 p-2">
          <MinusIcon class="fill-current text-red-600 h-5 w-5" />
        </button>
      </div>
    </li>
  );
}

// TODO: add functionality for plus and minus icons
// TODO: change the ColorTypeForms to display or not display depending on a button click