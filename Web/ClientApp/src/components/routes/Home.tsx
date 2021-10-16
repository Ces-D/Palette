import Container from "../general/Container";
import PaletteContainer from "../palette/PaletteContainer";
import ColorItem from "../palette/ColorItem";

export default function Home() {
  return (
    <Container>
      <PaletteContainer>
        <>
          <ColorItem />
        </>
      </PaletteContainer>
    </Container>
  );
}
