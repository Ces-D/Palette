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
 * @see  {ColorControllerGenerate}
 */
export const pushColorModel = createAsyncThunk(
  "color/fetchColorModel",
  async (requestBody: ColorControllerGenerateColorModel) => {
    const response = await axios.post("api/Color", requestBody);
    return response.data;
  }
);

/**
 * @method GET
 * @summary This fetches a new random color model
 */
export const pushRandomColorModel = createAsyncThunk(
  "color/fetchRandomColorModel",
  async () => {
    const response = await axios.get("api/Color");
    return response.data;
  }
);

const colorSlice = createSlice({
  name: "color",
  initialState: initialColorState,
  reducers: {
    removeColorModel(state, action: PayloadAction<{ id: string }>) {
      state.filter((color) => color.id !== action.payload.id);
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(pushColorModel.fulfilled, (state, action) => {
        const color = action.payload;
        state.push(color);
      })
      .addCase(pushRandomColorModel.fulfilled, (state, action) => {
        const color = action.payload;
        state.push(color);
      });
  },
});

export const { removeColorModel } = colorSlice.actions;
export default colorSlice.reducer;
