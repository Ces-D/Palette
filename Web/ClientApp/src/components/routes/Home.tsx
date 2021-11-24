import { useEffect } from "react";
import { fetchRandomColorModel } from "../../store/Color/colorSlice";
import { useAppDispatch, useAppSelector } from "../../store/hooks";
import Palette from "../palette/Palette";

export default function Home() {
  const colorStates = useAppSelector((state) => state.colors);
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (colorStates.length === 0) {
      dispatch(fetchRandomColorModel());
    }
  }, []);

  return (
    <div className="w-full relative">
      <Palette />
    </div>
  );
}

//TODO: implement the color harmony features
// TODO: error with the way we map to create the colorForm. Think on this
