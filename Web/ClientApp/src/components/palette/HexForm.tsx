import { useState, useEffect } from "react";
import { Hex } from "../contexts/ColorPalette/types";
import ColorInputSection from "../general/form/ColorInputSection";
import ColorSelectSection from "../general/form/ColorSelectSection";
import { ColorValueProps } from "../hooks/useColorGenerator";
import { BaseColorFormProps } from "./ColorFormDisplayContainer";

type Props = Hex &
  BaseColorFormProps & {
    colorHandler: ColorValueProps<Hex>;
  };

export default function HexForm(props: Props) {
  const [hex, setHex] = useState(props.color);

  useEffect(() => {
    props.colorHandler.setColorValue({ color: hex });
  });

  return (
    <div title={props.value} className="p-2 bg-white rounded-sm w-60">
      <ColorInputSection
        nonRangeInputType={"string"}
        maxLength={7}
        title="HEX"
        inputStyleClass="border"
        titleWidthClass="w-1/4"
        inputWidthClass="w-3/4"
        value={hex}
        onChangeHandler={(e) => setHex(e.target.value)}
      />
      <ColorSelectSection
        selected={props.selectSection.selected}
        setColorType={props.selectSection.setColorType}
      />
    </div>
  );
}
