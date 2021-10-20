export type ColorPaletteStateType = {
  colors: Color[];
  palette: string;
};

export type ColorPaletteActionType = ColorAction | PaletteAction;

export type Color = {
  id: string;
  rgb: string;
  hex: string;
  hsv: string;
};

export type ColorAction =
  | { type: "add-color" }
  | { type: "remove-color"; payload: { colorId: string } }
  | { type: "update-color"; payload: { color: Color; colorId: string } }
  | { type: "reset" };

export type PaletteAction = { type: "checkout-palette"; payload: { paletteId: string } };
