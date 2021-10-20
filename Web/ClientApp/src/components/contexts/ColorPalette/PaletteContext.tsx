import { createContext, Dispatch, useReducer } from "react";
import { v4 as uuidv4 } from "uuid";
import colorReducer, { generateDefaultColor } from "./colorReducer";
import paletteReducer from "./paletteReducer";
import { ColorPaletteActionType, ColorPaletteStateType } from "./types";

const INITIAL_COLOR_PALETTE_STATE: ColorPaletteStateType = {
  colors: [generateDefaultColor()],
  palette: uuidv4(),
};

/**
 * Separates handler logic for palette and colors, but the same action is passed
 * @param state
 * @param action both PaletteActions and ColorActions
 * @returns
 */
const mainReducer = (state: ColorPaletteStateType, action: ColorPaletteActionType) => ({
  colors: colorReducer(state.colors, action),
  palette: paletteReducer(state.palette, action),
});

export const PaletteContext = createContext<{
  state: ColorPaletteStateType;
  dispatch: Dispatch<ColorPaletteActionType>;
}>({ state: INITIAL_COLOR_PALETTE_STATE, dispatch: () => null });

export default function PaletteContextProvider(props: { children: React.ReactChild }) {
  const [state, dispatch] = useReducer(mainReducer, INITIAL_COLOR_PALETTE_STATE);

  return (
    <PaletteContext.Provider value={{ state, dispatch }}>
      {props.children}
    </PaletteContext.Provider>
  );
}
