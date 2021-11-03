import { useState } from "react";
import LockOpenIcon from "../general/icons/LockOpenIcon";
import LockClosedIcon from "../general/icons/LockClosedIcon";
import ColorFormDisplayContainer from "./ColorFormDisplayContainer";
import { Color, removeColorModel } from "../../store/Color/colorSlice";
import TrashIcon from "../general/icons/TrashIcon";
import { useAppDispatch } from "../../store/hooks";

export default function ColorItem(props: Color) {
  const [itemColor, setItemColor] = useState(props.rgb.color);
  const dispatch = useAppDispatch();
  const [lock, setLocked] = useState(false);

  return (
    <li
      className="flex-grow sm:h-96 border border-solid"
      style={{ backgroundColor: itemColor }}
    >
      <div className="flex flex-col justify-around items-center p-2 h-full text-red-200">
        <button
          onClick={() => {
            !lock && dispatch(removeColorModel({ id: props.id }));
          }}
          className={
            lock
              ? "bg-gray-800 rounded-full text-gray-400 cursor-not-allowed"
              : "rounded-full hover:bg-gray-50 p-2"
          }
        >
          <TrashIcon class="fill-current h-5 w-5" />
        </button>
        <button
          className="rounded-full hover:bg-gray-50 p-2"
          onClick={() => setLocked(!lock)}
        >
          {!lock ? (
            <LockOpenIcon class="fill-current h-5 w-5" />
          ) : (
            <LockClosedIcon class="fill-current h-5 w-5" />
          )}
        </button>
        <ColorFormDisplayContainer
          color={props}
          setItemContainerBackgroundColor={setItemColor}
        />
      </div>
    </li>
  );
}
