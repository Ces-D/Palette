import { useState } from "react";
import { Rgb } from "../../store/Color/colorSlice";
import ColorInputSection from "../general/form/ColorInputSection";
import ColorSelectSection from "../general/form/ColorSelectSection";
import { ColorForm } from "../hooks/useColorGenerator";
import { BaseColorFormProps } from "./ColorFormDisplayContainer";

export type Props = BaseColorFormProps & ColorForm<Rgb>;

export default function RgbForm(props: Props) {
  const [red, setRed] = useState(props.color.red);
  const [green, setGreen] = useState(props.color.green);
  const [blue, setBlue] = useState(props.color.blue);

  return (
    <div title={props.value} className="p-2 bg-white rounded-sm w-full sm:w-64">
      <ColorInputSection
        title="Red"
        max={255}
        min={0}
        value={red}
        onChangeHandler={(e) => setRed(e.target.valueAsNumber)}
        range={true}
        rangeClasses="bg-red-500 appearance-none w-full h-1 rounded outline-none slider-thumb py-1"
      />
      <ColorInputSection
        title="Green"
        max={255}
        min={0}
        value={green}
        onChangeHandler={(e) => setGreen(e.target.valueAsNumber)}
        range={true}
        rangeClasses="bg-green-500 appearance-none w-full h-1 rounded outline-none slider-thumb py-1"
      />
      <ColorInputSection
        title="Blue"
        max={255}
        min={0}
        value={blue}
        onChangeHandler={(e) => setBlue(e.target.valueAsNumber)}
        range={true}
        rangeClasses="bg-blue-500 appearance-none w-full h-1 rounded outline-none slider-thumb py-1"
      />
      <ColorSelectSection
        selected={props.baseSelectSection.activeColorType}
        onChangeHandler={(e) => {
          props.setColor({
            color: `rgb(${red}, ${green}, ${blue})`,
            red: red,
            green: green,
            blue: blue,
          });
          props.fetchModelColorValues();
          props.baseSelectSection.setActiveColorType(e.target.value);
        }}
        hexColorValue={props.baseSelectSection.hexValue}
      />
    </div>
  );
}
