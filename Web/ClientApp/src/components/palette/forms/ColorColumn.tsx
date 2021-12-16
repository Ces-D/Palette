import { useState } from "react";
import { ActionIcon, Group, Popover } from "@mantine/core";
import MinusIcon from "../../general/icons/MinusIcon";
import { useAppDispatch } from "../../../store/hooks";
import { fetchColorModel, removeColorModel } from "../../../store/Color/colorSlice";
import RgbForm from "../RgbForm";
import HslForm from "../HslForm";
import { BuildColorType, ColorState } from "../../../store/Color/types";
import useRequestUpdatedColorModel from "../../hooks/useRequestUpdatedColorModel";

interface ColorColumnProps {
  colorState: ColorState;
}

export default function ColorColumn(props: ColorColumnProps) {
  const dispatch = useAppDispatch();
  const [opened, setOpened] = useState(false);
  const {
    // requestUpdateAndChangeColorType, // Currently never being used
    colorId,
    isRgbActiveColorType,
    formHslColor,
    formRgbColor,
    rgbForm,
    hslForm,
  } = useRequestUpdatedColorModel(
    props.colorState.color,
    props.colorState.activeColorType
  );

  return (
    <Group
      className="w-full h-96"
      position="center"
      align="end"
      style={{
        backgroundColor: isRgbActiveColorType ? formRgbColor : formHslColor,
      }}
    >
      <Popover
        opened={opened}
        onClose={() =>
          isRgbActiveColorType
            ? dispatch(
                fetchColorModel({
                  colorType: BuildColorType.Rgb,
                  color: formRgbColor,
                  id: colorId,
                })
              )
            : dispatch(
                fetchColorModel({
                  colorType: BuildColorType.Hsl,
                  color: formHslColor,
                  id: colorId,
                })
              )
        }
        withArrow
        withCloseButton
        placement="center"
        position="top"
        title="Adjust your Color"
        target={
          <div className="w-full my-4 text-red-500">
            <ActionIcon
              className="mx-auto"
              onClick={() => dispatch(removeColorModel({ id: colorId }))}
            >
              <MinusIcon class="h-6 w-6 text-red-500" />
            </ActionIcon>
            <button onClick={() => setOpened(true)}>
              <h2 className="text-md px-1">
                {isRgbActiveColorType ? formRgbColor : formHslColor}
              </h2>
            </button>
          </div>
        }
      >
        {isRgbActiveColorType ? <RgbForm form={rgbForm} /> : <HslForm form={hslForm} />}
      </Popover>
    </Group>
  );
}
