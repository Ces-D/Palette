import React from "react";
import Header from "./general/Header";
import PaletteContextProvider from "../components/contexts/ColorPalette/PaletteContext";

type Props = {
  children: React.ReactNode;
};

export default function Layout(props: Props) {
  return (
    <PaletteContextProvider>
      <>
        <Header />
        {props.children}
      </>
    </PaletteContextProvider>
  );
}
