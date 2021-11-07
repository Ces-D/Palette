import { Dispatch, SetStateAction } from "react";
import { ColorType, Rgb } from "../../../store/Color/types";

/**
 * @property {ColorType} selected: the currently chosen color type
 * @property {Function} setActiveColorType: function that gets called when value changes. Currently being used to set the active color type of the parent component
 * @property {string} hexColorValue: string representation of the current hex color
 */
export type ColorSelectSectionProps = {
  selected: ColorType | string;
  setActiveColorType: Dispatch<SetStateAction<ColorType | string>>;
  rgbColor: Rgb;
};

export default function ColorSelectSection(props: ColorSelectSectionProps) {
  return (
    <section className="flex w-full justify-between">
      <select
        className="bg-white w-20 py-0.5 px-0 rounded-sm"
        name="selectType"
        id="selectType"
        value={props.selected}
        onChange={(e) => {
          props.setActiveColorType(e.target.value);
        }}
      >
        <option value="rgb">RGB</option>
        <option value="hsv">HSV</option>
      </select>
      <h2>{`#${props.rgbColor.red.toString(16).toUpperCase()}${props.rgbColor.green
        .toString(16)
        .toUpperCase()}${props.rgbColor.blue.toString(16).toUpperCase()}`}</h2>
    </section>
  );
}
