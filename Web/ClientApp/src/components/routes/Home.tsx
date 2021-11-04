import { useEffect } from "react";
import Container from "../general/Container";
import ColorItem from "../palette/ColorItem";
import PlusIcon from "../general/icons/PlusIcon";
import { useAppDispatch, useAppSelector } from "../../store/hooks";
import { fetchRandomColorModel } from "../../store/Color/colorSlice";

export default function Home() {
  const colors = useAppSelector((state) => state.colors);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchRandomColorModel());
  }, []);

  return (
    <Container>
      <ul className="flex flex-col md:flex-row relative">
        {colors.map((paletteColor, index) => (
          <ColorItem key={paletteColor.id} index={index} />
        ))}
        <button
          onClick={() => {
            dispatch(fetchRandomColorModel());
          }}
          className="absolute bottom-3 md:bottom-1/2 right-5 rounded-full bg-gray-50 hover:bg-gray-600"
        >
          <PlusIcon class="fill-current text-red-600 h-5 w-5" />
        </button>
      </ul>
    </Container>
  );
}

//TODO: implement the color harmony features
// TODO: implement changing color when moving the slider
