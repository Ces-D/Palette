import { Dispatch, SetStateAction, useState } from "react";
import { v4 as uuidv4 } from "uuid";
import { ColorType } from "../../store/Color/colorSlice";
import Switch from "../general/Switch";
import useColorGenerator, { UseColorGeneratorProps } from "../hooks/useColorGenerator";
// import HexForm from "./HexForm"; // TODO: consider deleting the hexForm
import HsvForm from "./HsvForm";
import RgbForm from "./RgbForm";

export type BaseColorFormProps = {
  value: ColorType;
  baseSelectSection: BaseSelectSection;
};
type BaseSelectSection = {
  activeColorType: ColorType | string;
  setActiveColorType: Dispatch<SetStateAction<ColorType | string>>;
  hexValue: string;
};

type Props = Omit<UseColorGeneratorProps, "value">;

export default function ColorFormDisplayContainer(props: Props) {
  const [displayForm, setDisplayForm] = useState(false);
  const [colorType, setColorType] = useState<ColorType | string>("rgb");
  const { rgbFormGenerator, hsvFormGenerator, hexFormGenerator } = useColorGenerator({
    color: props.color,
    value: colorType,
    setItemContainerBackgroundColor: props.setItemContainerBackgroundColor,
  });

  const selectSection: BaseSelectSection = {
    activeColorType: colorType,
    setActiveColorType: setColorType,
    hexValue: hexFormGenerator.color.color,
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
