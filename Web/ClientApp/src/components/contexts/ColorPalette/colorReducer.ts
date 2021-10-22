import { Color, ColorPaletteActionType, Rgb, Hex, Hsv } from "./types";
import { v4 as uuidv4 } from "uuid";

export const generateDefaultRgb = (): Rgb => {
  return {
    color: "rgb(255, 255, 255)",
    red: 255,
    green: 255,
    blue: 255,
  };
};

export const generateDefaultHex = (): Hex => {
  return { color: "#ffffff" };
};

export const generateDefaultHsv = (): Hsv => {
  return {
    color: "hsv(0, 0, 100%)",
    hue: 0,
    saturation: 0,
    hValue: 100,
  };
};

export const generateDefaultColor = (): Color => {
  return {
    id: uuidv4(),
    hex: generateDefaultHex(),
    hsv: generateDefaultHsv(),
    rgb: generateDefaultRgb(),
  };
};

export default function colorReducer(colors: Color[], action: ColorPaletteActionType) {
  switch (action.type) {
    case "add-color": {
      return [...colors, generateDefaultColor()];
    }
    case "remove-color": {
      return colors.filter((color) => color.id !== action.payload.colorId);
    }
    case "update-color": {
      return colors.map((color) =>
        color.id === action.payload.colorId ? { ...action.payload.color } : { ...color }
      );
    }
    case "reset": {
      return [generateDefaultColor()];
    }
    default: {
      return colors;
    }
  }
}

// TODO: change the color model to replicate the api color model
// TODO: update the reducers to implement that new model
