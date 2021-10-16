import React from "react";
import Header from "./general/Header";

type Props = {
  children: React.ReactNode;
};

export default function Layout(props: Props) {
  return (
    <>
      <Header />
      {props.children}
    </>
  );
}
