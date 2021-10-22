import { useContext } from "react";
import Container from "../general/Container";
import ColorItem from "../palette/ColorItem";
import { PaletteContext } from "../contexts/ColorPalette/PaletteContext";
import PlusIcon from "../general/icons/PlusIcon";

export default function Home() {
  const { state, dispatch } = useContext(PaletteContext);

  return (
    <Container>
      <ul className="flex flex-col sm:flex-row relative">
        {state.colors.map((paletteColor) => (
          <ColorItem key={paletteColor.id} {...paletteColor} />
        ))}
        <button
          onClick={() => {
            dispatch({ type: "add-color" });
          }}
          className="absolute bottom-3 sm:bottom-1/2 right-5 rounded-full bg-gray-50 hover:bg-gray-600"
        >
          <PlusIcon class="fill-current text-red-600 h-5 w-5" />
        </button>
      </ul>
    </Container>
  );
}

//TODO: implement the color harmony features