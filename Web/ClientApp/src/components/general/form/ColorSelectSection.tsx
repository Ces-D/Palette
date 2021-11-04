import { ChangeEventHandler } from "react";
import { ColorType } from "../../../store/Color/colorSlice";

/**
 * @property {ColorType} selected: the currently chosen color type
 * @property {Function} onChangeHandler: function that gets called when value changes. Currently being used to dispatch the update colorModel action
 * @property {string} hexColorValue: string representation of the current hex color
 */
export type ColorSelectSectionProps = {
  selected: ColorType | string;
  onChangeHandler: ChangeEventHandler<HTMLSelectElement>;
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
