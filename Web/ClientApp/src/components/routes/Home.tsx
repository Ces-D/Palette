import { useEffect } from "react";
import { v4 as uuidv4 } from "uuid";
import Container from "../general/Container";
import ColorItem from "../palette/ColorItem";
import PlusIcon from "../general/icons/PlusIcon";
import { useAppDispatch, useAppSelector } from "../../store/hooks";
import { fetchRandomColorModel } from "../../store/Color/colorSlice";

export default function Home() {
  const colorStates = useAppSelector((state) => state.colors);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchRandomColorModel());
  }, []);

  return (
    <Container>
      <ul className="flex flex-col md:flex-row relative">
        {colorStates.map((colorState) => (
          <ColorItem key={uuidv4()} {...colorState} />
        ))}
        <button
          onClick={() => {
            dispatch(fetchRandomColorModel());
          }}
          className="absolute bottom-3 md:bottom-1/2 right-5 bg-gray-50 hover:bg-gray-600 icon-button"
        >
          <PlusIcon class="text-red-600" />
        </button>
      </ul>
    </Container>
  );
}

//TODO: implement the color harmony features
