import ColorInputSection from "../general/form/ColorInputSection";
import ColorSelectSection from "../general/form/ColorSelectSection";
import { ColorFormProps } from "./ColorItem";

export default function HexForm(props: ColorFormProps) {

  return (
    <div title={props.value} className="p-2 bg-white rounded-sm w-60">
      <ColorInputSection
        nonRangeInputType={"string"}
        maxLength={7}
        title="HEX"
        inputStyleClass="border"
        titleWidthClass="w-1/4"
        inputWidthClass="w-3/4"
        value={props.color.colorValue}
        onChangeHandler={(e) => props.color.setColorValue(e.target.value)}
      />
      <ColorSelectSection
        selected={props.selectSection.selected}
        setColorType={props.selectSection.setColorType}
      />
    </div>
  );
}
