import Container from "../general/Container";
import ColorItem from "../palette/ColorItem";
import PlusIcon from "../general/icons/PlusIcon";
import { useAppSelector } from "../../store/hooks";
import usePaletteController from "../hooks/usePaletteController";

export default function Home() {
  const colors = useAppSelector((state) => state.colors);
  const { addNewColor } = usePaletteController();

  return (
    <Container>
      <ul className="flex flex-col sm:flex-row relative">
        {colors.map((paletteColor) => (
          <ColorItem key={paletteColor.id} {...paletteColor} />
        ))}
        <button
          onClick={() => {
            addNewColor();
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
