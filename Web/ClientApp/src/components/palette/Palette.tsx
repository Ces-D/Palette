import { ActionIcon } from "@mantine/core";
import { v4 } from "uuid";
import { fetchRandomColorModel } from "../../store/Color/colorSlice";
import { useAppDispatch, useAppSelector } from "../../store/hooks";
import PlusIcon from "../general/icons/PlusIcon";
import ColorColumn from "./forms/ColorColumn";

export default function Palette() {
  const colorStates = useAppSelector((state) => state.colors);
  const dispatch = useAppDispatch();

  return (
    <section className="relative">
      <ul className="w-full flex flex-row">
        {colorStates.map((colorState) => (
          <ColorColumn key={v4()} colorState={colorState} />
        ))}
      </ul>
      <ActionIcon
        onClick={() => {
          dispatch(fetchRandomColorModel());
        }}
        variant="hover"
        size="lg"
        radius="xl"
        className="absolute bottom-3 md:bottom-1/2 right-5"
      >
        <PlusIcon class="text-red-500" />
      </ActionIcon>
    </section>
  );
}
