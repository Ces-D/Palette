import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
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
}

export interface Color {
  id: string | null;
  rgb: Rgb | null;
  hex: Hex | null;
  hsv: Hsv | null;
  status: "pending" | "fulfilled" | "rejected";
}

const initialColorState: Color = {
  id: null,
  status: "pending",
  rgb: null,
  hex: null,
  hsv: null,
};

/**
 * @method POST
 * @summary This fetches a new color model calculated from a specific color type string
 * @see  {ColorControllerGenerate}
 */
export const fetchColorModel = createAsyncThunk(
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
export const fetchRandomColorModel = createAsyncThunk(
  "color/fetchRandomColorModel",
  async () => {
    const response = await axios.get("api/Color");
    return response.data;
  }
);

const colorSlice = createSlice({
  name: "color",
  initialState: initialColorState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchColorModel.pending, (state, action) => {
        state.status = "pending";
      })
      .addCase(fetchColorModel.fulfilled, (state, action) => {
        const color = action.payload;
        state = { ...color, status: "fulfilled" };
      })
      .addCase(fetchColorModel.rejected, (state, action) => {
        state.status = "rejected";
      })
      .addCase(fetchRandomColorModel.pending, (state, action) => {
        state.status = "pending";
      })
      .addCase(fetchColorModel.fulfilled, (state, action) => {
        const color = action.payload;
        state = { ...color, status: "fulfilled" };
      })
      .addCase(fetchRandomColorModel.rejected, (state, action) => {
        state.status = "rejected";
      });
  },
});

export default colorSlice.reducer;
