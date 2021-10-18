import Container from "../general/Container";
import ColorItem from "../palette/ColorItem";
import usePalette from "../hooks/usePalette";

export default function Home() {
  const { paletteKeys } = usePalette();

  return (
    <Container>
      <ul className="flex flex-col sm:flex-row">
        {paletteKeys().map((colorKey) => (
          <ColorItem key={colorKey} colorKey={colorKey} />
        ))}
      </ul>
    </Container>
  );
}
