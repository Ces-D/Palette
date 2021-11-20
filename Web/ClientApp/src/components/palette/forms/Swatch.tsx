import { Popover } from "@mantine/core";
import UtilityIcons from "./UtilityIcons";
import { useAppDispatch } from "../../../store/hooks";
import { removeColorModel, setLocked } from "../../../store/Color/colorSlice";
import { useState } from "react";

/**
 * @property children:  The component that will render as the popover
 */
export interface SwatchProps {
  buttonStyles: React.CSSProperties | undefined;
  children: React.ReactChild;
  lockedStatus: boolean;
  colorId: string;
}

/**
 * Component that renders the color swatch as a clickable button and on click the popover form
 * @param props { SwatchProps }
 * @returns
 */
export default function Swatch(props: SwatchProps) {
  const dispatch = useAppDispatch();
  const [opened, setOpened] = useState(false);

  return (
    <div className="flex justify-center items-center">
      <Popover
        opened={opened}
        onClose={() => setOpened(false)}
        position="bottom"
        placement="center"
        withArrow
        withCloseButton
        transition="fade"
        title="Adjust your Color"
        target={
          <div
            onClick={() => setOpened((o) => !o)}
            style={props.buttonStyles}
            className="h-36 w-32 rounded-3xl cursor-pointer"
          >
            <UtilityIcons
              locked={props.lockedStatus}
              lockOnClick={() => {
                dispatch(setLocked({ id: props.colorId }));
              }}
              trashOnClick={() => {
                dispatch(removeColorModel({ id: props.colorId }));
              }}
            />
          </div>
        }
      >
        {props.children}
      </Popover>
    </div>
  );
}
