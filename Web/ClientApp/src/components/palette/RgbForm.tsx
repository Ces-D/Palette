import { Rgb } from "../../store/Color/types";
import ColorInputSection from "../general/form/ColorInputSection";
import ColorSelectSection from "../general/form/ColorSelectSection";
import { ColorFormGenerator } from "../hooks/useColorGenerator";
import { BaseColorFormProps } from "./ColorFormDisplayContainer";
import { useAppDispatch } from "../../store/hooks";
import { updateRgbValueOfColorModel } from "../../store/Color/colorSlice";

export type Props = BaseColorFormProps & ColorFormGenerator<Rgb>;

export default function RgbForm(props: Props) {
  const dispatch = useAppDispatch();

  return (
    <div title={props.value} className="p-2 bg-white rounded-sm w-full sm:w-64">
      <ColorInputSection
        title="Red"
        max={255}
        min={0}
        value={props.color.red}
        onChangeHandler={(e) => {
          dispatch(
            updateRgbValueOfColorModel({
              id: props.id,
              colorValue: e.target.valueAsNumber,
              rgbType: "r",
            })
          );
        }}
        range={true}
        rangeClasses="bg-red-500 appearance-none w-full h-1 rounded outline-none slider-thumb py-1"
      />
      <ColorInputSection
        title="Green"
        max={255}
        min={0}
        value={props.color.green}
        onChangeHandler={(e) => {
          dispatch(
            updateRgbValueOfColorModel({
              id: props.id,
              colorValue: e.target.valueAsNumber,
              rgbType: "g",
            })
          );
        }}
        range={true}
        rangeClasses="bg-green-500 appearance-none w-full h-1 rounded outline-none slider-thumb py-1"
      />
      <ColorInputSection
        title="Blue"
        max={255}
        min={0}
        value={props.color.blue}
        onChangeHandler={(e) => {
          dispatch(
            updateRgbValueOfColorModel({
              id: props.id,
              colorValue: e.target.valueAsNumber,
              rgbType: "b",
            })
          );
        }}
        range={true}
        rangeClasses="bg-blue-500 appearance-none w-full h-1 rounded outline-none slider-thumb py-1"
      />
      <ColorSelectSection
        selected={props.baseSelectSection.selected}
        setActiveColorType={props.baseSelectSection.setActiveColorType}
        rgbColor={props.baseSelectSection.rgbColor}
      />
    </div>
  );
}
