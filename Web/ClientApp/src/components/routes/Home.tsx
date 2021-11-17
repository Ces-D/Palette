import { useEffect } from "react";
import { v4 as uuidv4 } from "uuid";
import PlusIcon from "../general/icons/PlusIcon";
import ColorItem from "../palette/ColorItem";
import { ActionIcon } from "@mantine/core";
import { useAppDispatch, useAppSelector } from "../../store/hooks";
import { fetchRandomColorModel } from "../../store/Color/colorSlice";

export default function Home() {
  const colorStates = useAppSelector((state) => state.colors);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchRandomColorModel());
  }, []);

  return (
    <>
      <ul className="flex flex-col md:flex-row relative min-h-56">
        {colorStates.map((colorState) => (
          <ColorItem key={uuidv4()} {...colorState} />
        ))}
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
      </ul>
    </>
  );
}

//TODO: implement the color harmony features
