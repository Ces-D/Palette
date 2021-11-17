import { ActionIcon } from "@mantine/core";
import LockClosedIcon from "../../general/icons/LockClosedIcon";
import LockOpenIcon from "../../general/icons/LockOpenIcon";
import TrashIcon from "../../general/icons/TrashIcon";

interface UtilityIconsProps {
  trashOnClick: () => void;
  lockOnClick: () => void;
  locked: boolean;
}

export default function UtilityIcons(props: UtilityIconsProps) {
  return (
    <div>
      <ActionIcon
        size="lg"
        variant="hover"
        radius="xl"
        disabled={props.locked ? true : false}
        onClick={props.trashOnClick}
        className="inline-block mr-5"
      >
        <TrashIcon class="m-auto" />
      </ActionIcon>
      <ActionIcon
        size="lg"
        variant="hover"
        radius="xl"
        className="inline-block"
        onClick={props.lockOnClick}
      >
        {props.locked ? (
          <LockClosedIcon class="m-auto" />
        ) : (
          <LockOpenIcon class="m-auto" />
        )}
      </ActionIcon>
    </div>
  );
}
