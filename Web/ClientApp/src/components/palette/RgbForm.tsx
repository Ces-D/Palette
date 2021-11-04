import { useState } from "react";
import { Rgb } from "../../store/Color/colorSlice";
import ColorInputSection from "../general/form/ColorInputSection";
import ColorSelectSection from "../general/form/ColorSelectSection";
import { ColorFormGenerator } from "../hooks/useColorGenerator";
import { BaseColorFormProps } from "./ColorFormDisplayContainer";

export type Props = BaseColorFormProps & ColorFormGenerator<Rgb>;

export default function RgbForm(props: Props) {
  const [redValue, setRedValue] = useState<number>(props.color.red);
  const [greenValue, setGreenValue] = useState<number>(props.color.green);
  const [blueValue, setBlueValue] = useState<number>(props.color.blue);

  const newRgbColor: Rgb = {
    color: `rgb(${redValue}, ${greenValue}, ${blueValue})`,
    red: redValue,
    green: greenValue,
    blue: blueValue,
  };

  return (
    <div title={props.value} className="p-2 bg-white rounded-sm w-full sm:w-64">
      <ColorInputSection
        title="Red"
        max={255}
        min={0}
        value={redValue}
        onChangeHandler={(e) => setRedValue(e.target.valueAsNumber)}
        range={true}
        rangeClasses="bg-red-500 appearance-none w-full h-1 rounded outline-none slider-thumb py-1"
      />
      <ColorInputSection
        title="Green"
        max={255}
        min={0}
        value={greenValue}
        onChangeHandler={(e) => setGreenValue(e.target.valueAsNumber)}
        range={true}
        rangeClasses="bg-green-500 appearance-none w-full h-1 rounded outline-none slider-thumb py-1"
      />
      <ColorInputSection
        title="Blue"
        max={255}
        min={0}
        value={blueValue}
        onChangeHandler={(e) => setBlueValue(e.target.valueAsNumber)}
        range={true}
        rangeClasses="bg-blue-500 appearance-none w-full h-1 rounded outline-none slider-thumb py-1"
      />
      <ColorSelectSection
        selected={props.baseSelectSection.activeColorType}
        onChangeHandler={() => {
          props.setColor(newRgbColor);
          props.fetchModelColorValues();
        }}
        hexColorValue={props.baseSelectSection.hexValue}
      />
    </div>
  );
}
