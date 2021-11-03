import { ChangeEvent } from "react";
import { ColorType } from "../../../store/Color/colorSlice";

export type ColorSelectSectionProps = {
  selected: ColorType | string;
  onChangeHandler: (e: ChangeEvent<HTMLSelectElement>) => void;
  hexColorValue: string;
};

export default function ColorSelectSection(props: ColorSelectSectionProps) {
  return (
    <section className="flex w-full justify-between">
      <select
        className="bg-white w-20 py-0.5 px-0 rounded-sm"
        name="selectType"
        id="selectType"
        value={props.selected}
        onChange={props.onChangeHandler}
      >
        <option value="rgb">RGB</option>
        <option value="hsv">HSV</option>
      </select>
      <h2>{props.hexColorValue}</h2>
    </section>
  );
}
