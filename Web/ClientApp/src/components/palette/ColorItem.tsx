import { useState } from "react";
import { ColorState } from "../../store/Color/types";
import { Popover, Group, Button, ActionIcon } from "@mantine/core";
import RgbForm from "./RgbForm";
import { useAppDispatch } from "../../store/hooks";
import { setLocked, removeColorModel } from "../../store/Color/colorSlice";
import { useForm, useToggle } from "@mantine/hooks";
import CogIcon from "../general/icons/CogIcon";
import UtilityIcons from "./forms/UtilityIcons";

export default function ColorItem(props: ColorState) {
  const dispatch = useAppDispatch();
  const [opened, setOpened] = useState(false);
  const rgbForm = useForm({
    initialValues: props.color.rgb,
    validationRules: {
      red: (value) => value >= 0 && value < 256,
      green: (value) => value >= 0 && value < 256,
      blue: (value) => value >= 0 && value < 256,
    },
  });
  const hslForm = useForm({
    initialValues: props.color.hsl,
    validationRules: {
      hue: (value) => value >= 0 && value < 256,
      saturation: (value) => value >= 0 && value < 256,
      lightness: (value) => value >= 0 && value < 256,
    },
  });
  const [colorType, toggle] = useToggle("rgb", ["rgb", "hsl"]);

  const formRgbColor = `rgb(${rgbForm.values.red}, ${rgbForm.values.green}, ${rgbForm.values.blue})`;
  const formHslColor = `hsl(${hslForm.values.hue}, ${hslForm.values.saturation}%, ${hslForm.values.lightness}%)`;

  return (
    <li
      style={{ backgroundColor: colorType === "rgb" ? formRgbColor : formHslColor }}
      className="w-full h-96"
    >
      <Group
        direction="column"
        align="center"
        spacing="md"
        className="h-full justify-end"
      >
        <div>
          <Button name={colorType} onClick={() => toggle()}>
            {colorType === "rgb" ? formRgbColor : formHslColor}
          </Button>
        </div>
        <Popover
          opened={opened}
          onClose={() => setOpened(false)}
          position="top"
          placement="end"
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
          <RgbForm form={rgbForm} />
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

// TODO: create the hsl Form and on ActionIcon Click of Popover then call on the api
