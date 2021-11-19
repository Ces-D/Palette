import SliderAndInput from "./forms/SliderAndInput";

interface HslFormProps {
  form: any;
}

export default function HslForm(props: HslFormProps) {
  return (
    <div className="w-72 md:w-96">
      <SliderAndInput
        header="Hue"
        min={0}
        max={360}
        value={props.form.values.hue}
        name="hue"
        onChange={(e) => props.form.setFieldValue("hue", e)}
        error={props.form.errors.hue && "Hue value must be between 0 and 360"}
        classNames={{
          root: "mt-2",
          track: "bg-indigo-700",
          bar: "bg-indigo-700",
          thumb: "bg-white border-indigo-700",
          label: "bg-white text-indigo-500 border border-solid border-indigo-500",
        }}
      />
      <SliderAndInput
        header="Saturation"
        min={0}
        max={100}
        value={props.form.values.saturation}
        name="saturation"
        onChange={(e) => props.form.setFieldValue("saturation", e)}
        error={
          props.form.errors.saturation && "Saturation value must be between 0 and 100"
        }
        classNames={{
          root: "mt-2",
          track: "bg-indigo-700",
          bar: "bg-indigo-700",
          thumb: "bg-white border-indigo-700",
          label: "bg-white text-indigo-500 border border-solid border-indigo-500",
        }}
      />
      <SliderAndInput
        header="Lightness"
        min={0}
        max={100}
        value={props.form.values.lightness}
        name="lightness"
        onChange={(e) => props.form.setFieldValue("lightness", e)}
        error={
          props.form.errors.lightness && "Lightness value must be between 0 and 100"
        }
        classNames={{
          root: "mt-2",
          track: "bg-indigo-700",
          bar: "bg-indigo-700",
          thumb: "bg-white border-indigo-700",
          label: "bg-white text-indigo-500 border border-solid border-indigo-500",
        }}
      />
    </div>
  );
}
