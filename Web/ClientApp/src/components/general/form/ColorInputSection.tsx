import { HTMLInputTypeAttribute } from "react";
import { ChangeEventHandler } from "react";

type Props = {
  title: string;
  value: number | string;
  onChangeHandler: ChangeEventHandler<HTMLInputElement> | undefined;
  nonRangeInputType?: HTMLInputTypeAttribute | undefined;
  max?: number;
  maxLength?: number;
  min?: number;
  range?: boolean;
  rangeClasses?: string;
  titleWidthClass?: string;
  inputStyleClass?:string;
  inputWidthClass?: string;
};

export default function ColorInputSection(props: Props) {
  return (
    <section className="py-0.5">
      <p className={`inline-block ${props.titleWidthClass || "w-3/4"}`}>{props.title}</p>
      <input
        className={`inline-block px-1 ${props.inputStyleClass} ${props.inputWidthClass || "w-1/4"}`}
        type={props.nonRangeInputType || "number"}
        max={props.max}
        min={props.min}
        maxLength={props.maxLength}
        value={props.value}
        onChange={props.onChangeHandler}
      />
      {(props.range || false) && (
        <input
          className={props.rangeClasses}
          type="range"
          value={props.value}
          min={props.min}
          max={props.max}
          onChange={props.onChangeHandler}
        />
      )}
    </section>
  );
}
