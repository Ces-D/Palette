import { useContext, useEffect, useState } from "react";
import { PaletteContext } from "../contexts/ColorPalette/PaletteContext";
import { Color } from "../contexts/ColorPalette/types";
import { ColorSelectSectionProps } from "../general/form/ColorSelectSection";
import Switch from "../general/Switch";
import useColorGenerator, { ColorValueProps } from "../hooks/useColorGenerator";
import HexForm from "./HexForm";
import HsvForm from "./HsvForm";
import RgbForm from "./RgbForm";

export type ColorTypes = "rgb" | "hex" | "hsv";

export type ColorFormProps = {
  color: ColorValueProps;
  value: ColorTypes;
  selectSection: ColorSelectSectionProps;
};

export default function ColorFormDisplayContainer(props: Color) {
  const { dispatch } = useContext(PaletteContext);
  const [displayForm, setDisplayForm] = useState(false);
  const [colorType, setColorType] = useState<ColorTypes | string>("rgb");
  const { hex, setHex, rgb, setRgb, hsv, setHsv, color } = useColorGenerator(props);

  const selectSection: ColorSelectSectionProps = {
    selected: colorType,
    setColorType: setColorType,
  };

  useEffect(() => {
    dispatch({ type: "update-color", payload: { color: color, colorId: props.id } });
  }, [hex, rgb, hsv]);

  return (
    <>
      <button onClick={() => setDisplayForm(!displayForm)}>
        <h2 className="text-white">
          {(colorType === "rgb" && rgb) ||
            (colorType === "hex" && hex) ||
            (colorType === "hsv" && hsv)}
        </h2>
      </button>
      {displayForm && (
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
      )}
    </>
  );
}


// TODO: style for mobile and other styling to make pretty
// TODO: could add a change color reducer action that calls api and sets other color values