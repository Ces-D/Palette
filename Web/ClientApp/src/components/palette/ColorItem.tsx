import LockOpenIcon from "../general/icons/LockOpenIcon";
import LockClosedIcon from "../general/icons/LockClosedIcon";
import ColorFormDisplayContainer from "./ColorFormDisplayContainer";
import { removeColorModel, setLocked } from "../../store/Color/colorSlice";
import { ColorState } from "../../store/Color/types";
import TrashIcon from "../general/icons/TrashIcon";
import { useAppDispatch } from "../../store/hooks";

export default function ColorItem(props: ColorState) {
  const dispatch = useAppDispatch();

  return (
    <li
      className="flex-grow border border-solid"
      style={{
        backgroundColor: `rgb(${props.color.rgb.red}, ${props.color.rgb.green}, ${props.color.rgb.blue})`,
      }}
    >
      <div className="flex flex-col justify-around items-center p-2 text-red-200 min-h-56 md:h-88">
        <div className="block">
        <button
          onClick={() => {
            !props.locked && dispatch(removeColorModel({ id: props.color.id }));
          }}
          className={`${
            props.locked
              ? "bg-gray-800 text-gray-400 cursor-not-allowed"
              : "hover:bg-gray-50"
          } icon-button mr-10`}
        >
          <TrashIcon />
        </button>
        <button
          className="hover:bg-gray-50 icon-button"
          onClick={() => dispatch(setLocked({ id: props.color.id }))}
        >
          {!props.locked ? <LockOpenIcon /> : <LockClosedIcon />}
        </button>
        </div>
        <ColorFormDisplayContainer {...props} />
      </div>
    </li>
  );
}
