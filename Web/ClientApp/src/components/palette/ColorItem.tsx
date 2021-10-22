import { useState, useContext } from "react";
import LockOpenIcon from "../general/icons/LockOpenIcon";
import LockClosedIcon from "../general/icons/LockClosedIcon";
import MinusIcon from "../general/icons/MinusIcon";
import ColorFormDisplayContainer from "./ColorFormDisplayContainer";
import { PaletteContext } from "../contexts/ColorPalette/PaletteContext";
import { Color } from "../contexts/ColorPalette/types";

export default function ColorItem(props: Color) {
  const { dispatch } = useContext(PaletteContext);
  const [lock, setLocked] = useState(false);
  console.log(props);

  return (
    <li className="flex-grow h-96" style={{ backgroundColor: props.rgb.color }}>
      <div className="flex flex-col justify-around items-center p-2 h-full">
        <button
          onClick={() => {
            !lock && dispatch({ type: "remove-color", payload: { colorId: props.id } });
          }}
          className={
            lock
              ? "bg-gray-800 rounded-full text-gray-400 cursor-not-allowed"
              : "rounded-full hover:bg-gray-50 p-2 text-red-600"
          }
        >
          <MinusIcon class="fill-current h-5 w-5" />
        </button>
        <button
          className="rounded-full hover:bg-gray-50 p-2 text-red-600"
          onClick={() => setLocked(!lock)}
        >
          {!lock ? (
            <LockOpenIcon class="fill-current h-5 w-5" />
          ) : (
            <LockClosedIcon class="fill-current h-5 w-5" />
          )}
        </button>
        <ColorFormDisplayContainer {...props} />
      </div>
    </li>
  );
}
