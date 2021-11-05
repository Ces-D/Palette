import { useState } from "react";
import { Hsv } from "../../store/Color/types";
import ColorInputSection from "../general/form/ColorInputSection";
import ColorSelectSection from "../general/form/ColorSelectSection";
import { ColorFormGenerator } from "../hooks/useColorGenerator";
import { BaseColorFormProps } from "./ColorFormDisplayContainer";

type Props = BaseColorFormProps & ColorFormGenerator<Hsv>;

export default function HsvForm(props: Props) {
  const [hueValue, setHueValue] = useState<number>(props.color.hue);
  const [saturationValue, setSaturationValue] = useState<number>(props.color.saturation);
  const [hsvValue, setHsvValue] = useState<number>(props.color.hValue);

  // const newHsvColor: Hsv = {
  //   color: `hsv(${hueValue}, ${saturationValue}%, ${hsvValue})`,
  //   hue: hueValue,
  //   saturation: saturationValue,
  //   hValue: hsvValue,
  // };

  return (
    <div title={props.value} className="p-2 bg-white rounded-sm w-60">
      <ColorInputSection
        title="Hue"
        max={359}
        min={0}
        value={hueValue}
        onChangeHandler={(e) => setHueValue(e.target.valueAsNumber)}
        range={true}
        rangeClasses="bg-gray-500 appearance-none w-full h-1 rounded outline-none slider-thumb"
        // consider adding style classes for range color
      />
      <ColorInputSection
        title="Saturation"
        max={100}
        min={0}
        value={saturationValue}
        onChangeHandler={(e) => setSaturationValue(e.target.valueAsNumber)}
        range={true}
        rangeClasses="bg-gray-500 appearance-none w-full h-1 rounded outline-none slider-thumb"
        // consider adding style classes for range color
      />
      <ColorInputSection
        title="Value"
        max={100}
        min={0}
        value={hsvValue}
        onChangeHandler={(e) => setHsvValue(e.target.valueAsNumber)}
        range={true}
        rangeClasses="bg-gray-500 appearance-none w-full h-1 rounded outline-none slider-thumb"
        // consider adding style classes for range color
      />
      <ColorSelectSection
        selected={props.baseSelectSection.activeColorType}
        setActiveColorType={props.baseSelectSection.setActiveColorType}
        hexColorValue={props.baseSelectSection.hexValue}
      />
    </div>
  );
}
