import { createSlice, createAsyncThunk, PayloadAction } from "@reduxjs/toolkit";
import axios from "axios";
import { Color, ColorControllerGenerateColorModel, ColorState } from "./types";

const initialColorState: ColorState[] = [];

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
      return state.filter((colorState) => colorState.color.id !== action.payload.id);
    },
    setIsFormDisplayed(state, action: PayloadAction<{ id: string }>) {
      const updateIndex = state.findIndex(
        (colorState) => colorState.color.id === action.payload.id
      );
      state[updateIndex].isFormDisplayed = !state[updateIndex].isFormDisplayed;
      return state;
    },
    setLocked(state, action: PayloadAction<{ id: string }>) {
      const updateIndex = state.findIndex(
        (colorState) => colorState.color.id === action.payload.id
      );
      state[updateIndex].locked = !state[updateIndex].locked;
      return state;
    },
    updateRedRgbValueOfColorModel(
      state,
      action: PayloadAction<{ id: string; redColor: number }>
    ) {
      const updateIndex = state.findIndex(
        (colorState) => colorState.color.id === action.payload.id
      );
      state[updateIndex].color.rgb.red = action.payload.redColor;
      return state;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(fetchColorModel.fulfilled, (state, action) => {
        const updateIndex = state.findIndex(
          (colorState) => colorState.color.id === action.payload.id
        );
        state[updateIndex].color.hex = action.payload.hex;
        state[updateIndex].color.hsv = action.payload.hsv;
        state[updateIndex].color.rgb = action.payload.rgb;
        return state;
      })
      .addCase(fetchRandomColorModel.fulfilled, (state, action) => {
        state.push({ locked: false, isFormDisplayed: false, color: action.payload });
      });
  },
});

export const {
  removeColorModel,
  updateRedRgbValueOfColorModel,
  setIsFormDisplayed,
  setLocked,
} = colorSlice.actions;
export default colorSlice.reducer;

// TODO: test the locked function and general cleaning
// TODO: add reducer for the remaing green and blue of rgb
