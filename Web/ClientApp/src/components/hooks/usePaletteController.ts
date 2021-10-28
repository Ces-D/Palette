import { pushRandomColorModel, removeColorModel } from "../../store/Color/colorSlice";
import { addColor, removeColor } from "../../store/Palette/paletteSlice";
import { useAppDispatch, useAppSelector } from "../../store/hooks";

/**
 * @summary Helper hook for managing the creation and removal of color items.
 * State for colors is managed through two reducers, Palette and Color reducers.
 *
 */
export default function usePaletteController() {
  const colorSelector = useAppSelector((state) => state.colors);
  const dispatch = useAppDispatch();

  const addNewColor = () => {
    dispatch(pushRandomColorModel());
    const latestColor = colorSelector[colorSelector.length - 1];
    dispatch(addColor({ colorId: latestColor.id }));
  };

  const removeExistingColor = (colorId: string) => {
    dispatch(removeColorModel({ id: colorId }));
    dispatch(removeColor({ colorId: colorId }));
  };

  return { addNewColor, removeExistingColor };
}
