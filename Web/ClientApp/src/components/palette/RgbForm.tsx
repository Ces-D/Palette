import { useEffect, useState } from "react";
import ColorInputSection from "../general/form/ColorInputSection";
import ColorSelectSection from "../general/form/ColorSelectSection";
import { ColorFormProps } from "./ColorItem";

export default function RgbForm(props: ColorFormProps) {
  const [red, setRed] = useState(0);
  const [green, setGreen] = useState(0);
  const [blue, setBlue] = useState(0);

  useEffect(() => {
    props.color.setColorValue(`rgb(${red}, ${green}, ${blue})`);
  }, [red, green, blue]);

  // TODO: consider deleting the plus minus icons from general/form/icon
  // TODO: consider creating a ColorFormContainer for the parent div here

  return (
    <div title={props.value} className="p-2 bg-white rounded-sm w-60">
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
        selected={props.selectSection.selected}
        setColorType={props.selectSection.setColorType}
      />
    </div>
  );
}
