import { ColorState } from "../../store/Color/types";
import { Button } from "@mantine/core";
import RgbForm from "./RgbForm";
import HslForm from "./HslForm";
import useRequestUpdatedColorModel from "../hooks/useRequestUpdatedColorModel";
import Swatch from "./forms/Swatch";

export default function ColorItem(props: ColorState) {
  const {
    requestUpdateAndChangeColorType,
    isRgbActiveColorType,
    rgbForm,
    hslForm,
    formHslColor,
    formRgbColor,
  } = useRequestUpdatedColorModel(props.color, props.activeColorType);

  return (
    <li className="my-2">
      <Swatch
        colorId={props.color.id}
        lockedStatus={props.locked}
        buttonStyles={{
          backgroundColor: isRgbActiveColorType ? formRgbColor : formHslColor,
        }}
      >
        {isRgbActiveColorType ? <RgbForm form={rgbForm} /> : <HslForm form={hslForm} />}
      </Swatch>
      <Button
        variant="link"
        onClick={() => requestUpdateAndChangeColorType()}
        className="w-full text-center mt-2"
      >
        <h2 className="text-lg">{isRgbActiveColorType ? formRgbColor : formHslColor}</h2>
      </Button>
    </li>
  );
}
