import { useState } from "react";
import { ColorState } from "../../store/Color/types";
import { Popover, Group, Button, ActionIcon } from "@mantine/core";
import RgbForm from "./RgbForm";
import HslForm from "./HslForm";
import { useAppDispatch } from "../../store/hooks";
import { setLocked, removeColorModel } from "../../store/Color/colorSlice";
import CogIcon from "../general/icons/CogIcon";
import UtilityIcons from "./forms/UtilityIcons";
import useRequestUpdatedColorModel from "../hooks/useRequestUpdatedColorModel";


export default function ColorItem(props: ColorState) {
  const dispatch = useAppDispatch();
  const [opened, setOpened] = useState(false);
  const { requestUpdateAndChangeColorType, isRgbActiveColorType, rgbForm, hslForm } =
    useRequestUpdatedColorModel(props.color, props.activeColorType);

  const formRgbColor = `rgb(${rgbForm.values.red}, ${rgbForm.values.green}, ${rgbForm.values.blue})`;
  const formHslColor = `hsl(${hslForm.values.hue}, ${hslForm.values.saturation}%, ${hslForm.values.lightness}%)`;

  return (
    <li
      style={{
        backgroundColor: isRgbActiveColorType ? formRgbColor : formHslColor,
      }}
      className="w-full h-40 md:h-96"
    >
      <Group
        direction="column"
        align="center"
        spacing="md"
        className="h-full justify-end"
      >
        <Button
          variant="link"
          onClick={() =>
            isRgbActiveColorType
              ? requestUpdateAndChangeColorType(rgbForm)
              : requestUpdateAndChangeColorType(hslForm)
          }
        >
          <h2 className="text-2xl">
            {isRgbActiveColorType ? formRgbColor : formHslColor}
          </h2>
        </Button>
        <Popover
          opened={opened}
          onClose={() => setOpened(false)}
          position="top"
          placement="center"
          withArrow
          withCloseButton
          transition="pop-top-right"
          title="Adjust your Color"
          target={
            <ActionIcon onClick={() => setOpened((o) => !o)}>
              <CogIcon class="h-6 w-6" />
            </ActionIcon>
          }
        >
          {isRgbActiveColorType ? <RgbForm form={rgbForm} /> : <HslForm form={hslForm} />}
        </Popover>
        <UtilityIcons
          locked={props.locked}
          lockOnClick={() => {
            dispatch(setLocked({ id: props.color.id }));
          }}
          trashOnClick={() => {
            dispatch(removeColorModel({ id: props.color.id }));
          }}
        />
      </Group>
    </li>
  );
}
