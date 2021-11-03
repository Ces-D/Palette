import { useState } from "react";
import { Hsv } from "../../store/Color/colorSlice";
import ColorInputSection from "../general/form/ColorInputSection";
import ColorSelectSection from "../general/form/ColorSelectSection";
import { ColorForm } from "../hooks/useColorGenerator";
import { BaseColorFormProps } from "./ColorFormDisplayContainer";

type Props = BaseColorFormProps & ColorForm<Hsv>;

export default function HsvForm(props: Props) {
  const [hue, setHue] = useState(props.color.hue);
  const [saturation, setSaturation] = useState(props.color.saturation);
  const [value, setValue] = useState(props.color.hValue);

  return (
    <div title={props.value} className="p-2 bg-white rounded-sm w-60">
      <ColorInputSection
        title="Hue"
        max={359}
        min={0}
        value={hue}
        onChangeHandler={(e) => setHue(e.target.valueAsNumber)}
        range={true}
        rangeClasses="bg-gray-500 appearance-none w-full h-1 rounded outline-none slider-thumb"
        // consider adding style classes for range color
      />
      <ColorInputSection
        title="Saturation"
        max={100}
        min={0}
        value={saturation}
        onChangeHandler={(e) => setSaturation(e.target.valueAsNumber)}
        range={true}
        rangeClasses="bg-gray-500 appearance-none w-full h-1 rounded outline-none slider-thumb"
        // consider adding style classes for range color
      />
      <ColorInputSection
        title="Value"
        max={100}
        min={0}
        value={value}
        onChangeHandler={(e) => setValue(e.target.valueAsNumber)}
        range={true}
        rangeClasses="bg-gray-500 appearance-none w-full h-1 rounded outline-none slider-thumb"
        // consider adding style classes for range color
      />
      <ColorSelectSection
        selected={props.baseSelectSection.activeColorType}
        onChangeHandler={(e) => {
          props.setColor({
            color: `hsv(${hue}, ${saturation}%, ${value}%)`,
            hue: hue,
            saturation: saturation,
            hValue: value,
          });
          props.fetchModelColorValues();
          props.baseSelectSection.setActiveColorType(e.target.value);
        }}
        hexColorValue={props.baseSelectSection.hexValue}
      />
    </div>
  );
}
