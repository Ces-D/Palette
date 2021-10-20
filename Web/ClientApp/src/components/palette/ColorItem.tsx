import { useState, useContext } from "react";
import { Color } from "../hooks/useColorGenerator";
import LockOpenClosed from "../general/icons/LockOpenIcon";
import LockClosedIcon from "../general/icons/LockClosedIcon";
import MinusIcon from "../general/icons/MinusIcon";
import ColorFormDisplayContainer from "./ColorFormDisplayContainer";
import { PaletteContext } from "../contexts/ColorPalette/PaletteContext";

export default function ColorItem(props: Color) {
  const { dispatch } = useContext(PaletteContext);
  const [lock, setLocked] = useState(false);

  return (
    <li className="flex-grow h-96" style={{ backgroundColor: props.rgb }}>
      <div className="flex flex-col justify-around items-center p-2 h-full">
        <ColorFormDisplayContainer {...props} />
        <button
          className="rounded-full hover:bg-gray-50 p-2 text-red-600"
          onClick={() => setLocked(!lock)}
        >
          {!lock ? (
            <LockOpenClosed class="fill-current h-5 w-5" />
          ) : (
            <LockClosedIcon class="fill-current h-5 w-5" />
          )}
        </button>
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
      </div>
    </li>
  );
}

// TODO: change the ColorTypeForms to display or not display depending on a button click
