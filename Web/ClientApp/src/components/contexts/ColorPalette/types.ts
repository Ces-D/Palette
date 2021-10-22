export type Rgb = {
  color: string;
  red: number;
  green: number;
  blue: number;
};

export type Hex = {
  color: string;
};

export type Hsv = {
  color: string;
  hue: number;
  saturation: number;
  hValue: number;
};

export type Color = {
  id: string;
  rgb: Rgb;
  hex: Hex;
  hsv: Hsv;
};

export type ColorPaletteStateType = {
  colors: Color[];
  paletteId: string;
};

export type ColorPaletteActionType = ColorAction | PaletteAction;

export type ColorAction =
  | { type: "add-color" }
  | { type: "remove-color"; payload: { colorId: string } }
  | { type: "update-color"; payload: { color: Color; colorId: string } }
  | { type: "reset" };

export type PaletteAction = { type: "checkout-palette"; payload: { paletteId: string } };
