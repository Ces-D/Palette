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
export const fetchColorModel = createAsyncThunk(
  "color/fetchColorModel",
  async (requestBody: ColorControllerGenerateColorModel) => {
    const response = await axios.post("api/Color", requestBody);
    console.log("FETCH COLOR MODEL: ", response.data);
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
    console.log("FETCH RANDOM COLOR MODEL: ", response.data);
    return response.data;
  }
);

const colorSlice = createSlice({
  name: "color",
  initialState: initialColorState,
  reducers: {
    updateExistingColorModel(
      state,
      action: PayloadAction<{ id: string; colorUpdates: Color }>
    ) {
      const targetColorIndex = state.findIndex((color) => {
        color.id === action.payload.id;
      });
      state[targetColorIndex] = {
        ...action.payload.colorUpdates,
        id: action.payload.id,
      };
    },
    removeColorModel(state, action: PayloadAction<{ id: string }>) {
      state = state.filter((color) => color.id !== action.payload.id);
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(fetchColorModel.fulfilled, (state, action) => {
        console.log(state.length);
        console.log("CASE FOR FETCH COLOR: ", action.payload);
        // console.log(action.meta)
      })
      .addCase(fetchRandomColorModel.fulfilled, (state, action) => {
        state.push(action.payload);
        console.log(state.length);
      });
  },
});

export const { removeColorModel, updateExistingColorModel } = colorSlice.actions;
export default colorSlice.reducer;

// TODO: the pushColorModel only handles the insert into state but doesnt take into account that the color may already exist and so only needs to the updated
