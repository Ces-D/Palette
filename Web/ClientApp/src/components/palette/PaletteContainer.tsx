import React from "react";

type Props = {
  children: React.ReactChild;
};
export default function PaletteContainer(props: Props) {
  return <ul className="flex flex-col sm:flex-row">{props.children}</ul>;
}
