import { useState, useEffect } from "react";
import { Hex } from "../../store/Color/colorSlice";
import ColorInputSection from "../general/form/ColorInputSection";
import { ColorForm } from "../hooks/useColorGenerator";

type Props = ColorForm<Hex>;

export default function HexForm(props: Props) {
  const [hex, setHex] = useState(props.color.color);

  useEffect(() => {
    props.setColor({ color: `#${hex}` });
  }, [hex]); // FIXME: Can never use setState inside of useEffect

  return (
    <div title="hex" className="p-2 bg-white rounded-sm w-60">
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
    </div>
  );
}
// TODO: Change this to readonly and always display on the bottom right
