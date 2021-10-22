import { Dispatch, SetStateAction } from "react";
import { ColorTypes } from "../../palette/ColorFormDisplayContainer";

export type ColorSelectSectionProps = {
  setColorType: Dispatch<SetStateAction<string>>;
  selected: ColorTypes | string;
};

export default function ColorSelectSection(props: ColorSelectSectionProps) {
  return (
    <section>
      <select
        className="bg-white w-20 py-0.5 px-0 rounded-sm"
        name="selectType"
        id="selectType"
        value={props.selected}
        onChange={(e) => props.setColorType(e.target.value)}
      >
        <option value="rgb">RGB</option>
        <option value="hsv">HSV</option>
        <option value="hex">HEX</option>
      </select>
    </section>
  );
}
