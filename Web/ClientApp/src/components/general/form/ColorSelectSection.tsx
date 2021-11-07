import { Dispatch, SetStateAction } from "react";
import { fetchColorModel } from "../../../store/Color/colorSlice";
import { ColorType, Rgb } from "../../../store/Color/types";
import { useAppDispatch } from "../../../store/hooks";

/**
 * @property {ColorType} selected: the currently chosen color type
 * @property {Function} setActiveColorType: function that gets called when value changes. Currently being used to set the active color type of the parent component
 * @property {string} hexColorValue: string representation of the current hex color
 */
export type ColorSelectSectionProps = {
  selected: ColorType | string;
  setActiveColorType: Dispatch<SetStateAction<ColorType | string>>;
  rgbColor: Rgb;
  colorId: string;
};

export default function ColorSelectSection(props: ColorSelectSectionProps) {
  const dispatch = useAppDispatch();

  const currentHexColor = `#${props.rgbColor.red
    .toString(16)
    .toUpperCase()}${props.rgbColor.green.toString(16).toUpperCase()}${props.rgbColor.blue
    .toString(16)
    .toUpperCase()}`;

  const currentRgbColor = `rgb(${props.rgbColor.red}, ${props.rgbColor.green}, ${props.rgbColor.blue})`;

  return (
    <section className="flex w-full justify-between">
      <select
        className="bg-white w-20 py-0.5 px-0 rounded-sm"
        value={props.selected}
        onChange={(e) => {
          dispatch(
            fetchColorModel({
              ColorId: props.colorId,
              ColorType: props.selected,
              ColorValue: currentRgbColor,
            })
          );
          props.setActiveColorType(e.target.value);
        }}
      >
        <option value="rgb">RGB</option>
      </select>
      <h2>{currentHexColor}</h2>
    </section>
  );
}

// TODO: test the dispatch of fetchColorModel and as more color method are added,
// figure out how to pass those active types as the input to the ColorValue in fetchColorModel
