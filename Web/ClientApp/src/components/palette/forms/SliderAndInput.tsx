import { NumberInput, Slider, SliderStylesNames } from "@mantine/core";
import React from "react";

interface SliderAndInputProps {
  header: string;
  min: number;
  max: number;
  value: number;
  name: string;
  onChange: (e: number) => void;
  error?: React.ReactNode;
  classNames?: Partial<Record<SliderStylesNames, string>>;
}

export default function SliderAndInput(props: SliderAndInputProps) {
  return (
    <section className="mt-4">
      <h3 className="w-3/4 inline-block">{props.header}</h3>
      <NumberInput
        value={props.value}
        name={props.name}
        onChange={props.onChange}
        max={props.max}
        min={props.min}
        error={props.error}
        className="w-1/4 inline-block"
      />
      <Slider
        value={props.value}
        name={props.name}
        labelTransition="fade"
        min={props.min}
        max={props.max}
        onChange={props.onChange}
        classNames={props.classNames}
      />
    </section>
  );
}
