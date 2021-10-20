import { Color, ColorPaletteActionType } from "./types";
import { v4 as uuidv4 } from "uuid";

export const generateDefaultColor = (): Color => {
  return {
    id: uuidv4(),
    hex: "#000000",
    hsv: "hsv(0, 0%, 0%)",
    rgb: "rgb(0, 0, 0)",
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
