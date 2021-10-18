import { Dispatch, SetStateAction } from "react";

export type ColorSelectSectionProps = {
  setColorType: Dispatch<SetStateAction<string>>;
  selected: string;
};

export default function ColorSelectSection(props: ColorSelectSectionProps) {
  return (
    <section>
      <select
        className="bg-white w-20 py-0.5 px-0 rounded-sm"
        name="selectType"
        id="selectType"
        onChange={(e) => props.setColorType(e.target.value)}
      >
        <option value="rgb" selected={"rgb" === props.selected}>
          RGB
        </option>
        <option value="hsv" selected={"hsv" === props.selected}>
          HSV
        </option>
        <option value="hex" selected={"hex" === props.selected}>
          HEX
        </option>
      </select>
    </section>
  );
}
