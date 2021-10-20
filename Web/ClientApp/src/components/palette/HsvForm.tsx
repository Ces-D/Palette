import { useState, useEffect } from "react";
import ColorInputSection from "../general/form/ColorInputSection";
import ColorSelectSection from "../general/form/ColorSelectSection";
import { ColorFormProps } from "./ColorFormDisplayContainer";

export default function HsvForm(props: ColorFormProps) {
  const [hue, setHue] = useState(0);
  const [saturation, setSaturation] = useState(0);
  const [value, setValue] = useState(0);

  useEffect(() => {
    props.color.setColorValue(`hsv(${hue}, ${saturation}%, ${value}%)`);
  }, [hue, saturation, value]);

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
        selected={props.selectSection.selected}
        setColorType={props.selectSection.setColorType}
      />
    </div>
  );
}
