// import { UseFormReturnType } from "./ColorItem";
import SliderAndInput from "./forms/SliderAndInput";

interface RgbFormProps {
  // form: UseFormReturnType<Rgb>;
  form: any;
}

export default function RgbForm(props: RgbFormProps) {
  return (
    <div className=" w-full md:w-96">
      <SliderAndInput
        header="Red"
        min={0}
        max={255}
        value={props.form.values.red}
        name="red"
        onChange={(e) => props.form.setFieldValue("red", e)}
        error={props.form.errors.red && "Red values must be between 0 and 255"}
        classNames={{
          root: "mt-2",
          track: "bg-red-700",
          bar: "bg-red-700",
          thumb: "bg-white border-red-700",
          label: "bg-white text-red-500 border border-solid border-red-500",
        }}
      />

      <SliderAndInput
        header="Green"
        min={0}
        max={255}
        value={props.form.values.green}
        name="red"
        onChange={(e) => props.form.setFieldValue("green", e)}
        error={props.form.errors.green && "Green values must be between 0 and 255"}
        classNames={{
          root: "mt-2",
          track: "bg-green-700",
          bar: "bg-green-700",
          thumb: "bg-white border-green-700",
          label: "bg-white text-green-500 border border-solid border-green-500",
        }}
      />
      <SliderAndInput
        header="Blue"
        min={0}
        max={255}
        value={props.form.values.blue}
        name="blue"
        onChange={(e) => props.form.setFieldValue("blue", e)}
        error={props.form.errors.blue && "Blue values must be between 0 and 255"}
        classNames={{
          root: "mt-2",
          track: "bg-blue-700",
          bar: "bg-blue-700",
          thumb: "bg-white border-blue-700",
          label: "bg-white text-blue-500 border border-solid border-blue-500",
        }}
      />
    </div>
  );
}
