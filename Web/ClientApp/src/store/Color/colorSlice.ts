import { createSlice, createAsyncThunk, PayloadAction } from "@reduxjs/toolkit";
import axios from "axios";

/**
 * @summary Model for the Rgb Color Model
 */
export interface Rgb {
  color: string;
  red: number;
  green: number;
  blue: number;
}

/**
 * @summary Model for the Hex Color Model
 */
export interface Hex {
  color: string;
}

/**
 * @summary Model for the Hsv Color Model
 */
export interface Hsv {
  color: string;
  hue: number;
  saturation: number;
  hValue: number;
}

export type ColorType = "rgb" | "hex" | "hsv";

/**
 * @summary The view model for the api POST request for ColorController
 */
export interface ColorControllerGenerateColorModel {
  ColorType: ColorType;
  ColorValue: string;
  ColorId: string;
}

export interface Color {
  id: string;
  rgb: Rgb;
  hex: Hex;
  hsv: Hsv;
}

const initialColorState: Color[] = [];

/**
 * @method POST
 * @summary This fetches a new color model calculated from a specific color type string
 * @see  {ColorControllerGenerateColorModel}
 */
export const fetchColorModel = createAsyncThunk(
  "color/fetchColorModel",
  async (requestBody: ColorControllerGenerateColorModel): Promise<Color> => {
    const response = await axios.post("api/Color", requestBody);
    return response.data;
  }
);

/**
 * @method GET
 * @summary This fetches a new random color model
 */
export const fetchRandomColorModel = createAsyncThunk(
  "color/fetchRandomColorModel",
  async (): Promise<Color> => {
    const response = await axios.get("api/Color");
    return response.data;
  }
);

const colorSlice = createSlice({
  name: "color",
  initialState: initialColorState,
  reducers: {
    removeColorModel(state, action: PayloadAction<{ id: string }>) {
      return state.filter((color) => color.id !== action.payload.id);
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(fetchColorModel.fulfilled, (state, action) => {
        const updateIndex = state.findIndex((color) => color.id === action.payload.id);
        state[updateIndex].hex = action.payload.hex;
        state[updateIndex].hsv = action.payload.hsv;
        state[updateIndex].rgb = action.payload.rgb;
        return state;
      })
      .addCase(fetchRandomColorModel.fulfilled, (state, action) => {
        state.push(action.payload);
      });
  },
});

export const { removeColorModel } = colorSlice.actions;
export default colorSlice.reducer;
