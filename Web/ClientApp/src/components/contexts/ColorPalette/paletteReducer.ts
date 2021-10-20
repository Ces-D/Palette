import { ColorPaletteActionType } from "./types";
//TODO: change the function so that when changing id, we load the associated colors
/**
 * consider adding a status for if I choose to add an author and login status
 * status: anonymous | <authorTag>
 * id: <paletteID>
 */

export default function paletteReducer(palette: string, action: ColorPaletteActionType) {
  switch (action.type) {
    case "checkout-palette": {
      return action.payload.paletteId;
    }
    default: {
      return palette;
    }
  }
}
