import { ActionIcon } from "@mantine/core";
import { useEffect } from "react";
import { v4 } from "uuid";
import { fetchRandomColorModel } from "../../store/Color/colorSlice";
import { useAppDispatch, useAppSelector } from "../../store/hooks";
import PlusIcon from "../general/icons/PlusIcon";
import ColorItem from "./ColorItem";

export default function Palette() {
  const colorStates = useAppSelector((state) => state.colors);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchRandomColorModel());
  }, []);

  return (
    <section className="w-full relative">
      <ul className="grid grid-cols-5">
        {colorStates.map((colorState) => (
          <ColorItem key={v4()} {...colorState} />
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

//TODO: this looks fine if there are many colorItems but not if there is only one