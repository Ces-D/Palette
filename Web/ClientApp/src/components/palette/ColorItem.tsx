// import { useState } from "react";

export default function ColorItem() {
  const INITIAL_COLOR = "rgb(157, 79, 30)";
  // const [rgb, setRgb] = useState<string | null>();
  // // const [hsv, setHsv] = useState<string | null>();
  // // const [hex, setHex] = useState<string | null>();

  // TODO: create rgb selector popout display
  // TODO: create hex input display
  // TODO: create hsv selector display
  return (
    <li className="flex-grow h-96" style={{ backgroundColor: INITIAL_COLOR }}>
      <div className="flex flex-col justify-around items-center ">
        <div>lock</div>
        <div>Remove</div>
      </div>
    </li>
  );
}
