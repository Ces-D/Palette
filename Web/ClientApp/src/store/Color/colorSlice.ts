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
    const response = await axios.post("api/Color/Build", requestBody);
    console.log("FETCH COLOR MODEL RESPONSE: ", response.data);
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
    const response = await axios.get("api/Color/Random");
    return response.data;
  }
);

const colorSlice = createSlice({
  name: "color",
  initialState: initialColorState,
  reducers: {
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
    removeColorModel(state, action: PayloadAction<{ id: string }>) {
      return state.filter((colorState) => colorState.color.id !== action.payload.id);
    },
    updateLocaleRgbValueOfColorModel(
      state,
      action: PayloadAction<{ id: string; colorValue: number; rgbType: "r" | "g" | "b" }>
    ) {
      const updateIndex = state.findIndex(
        (colorState) => colorState.color.id === action.payload.id
      );
      switch (action.payload.rgbType) {
        case "r":
          state[updateIndex].color.rgb.red = action.payload.colorValue;
          break;
        case "g":
          state[updateIndex].color.rgb.green = action.payload.colorValue;
          break;
        case "b":
          state[updateIndex].color.rgb.blue = action.payload.colorValue;
          break;
        default:
          break;
      }
      return state;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(fetchColorModel.fulfilled, (state, action) => {
        const updateIndex = state.findIndex(
          (colorState) => colorState.color.id === action.payload.id
        );
        state[updateIndex].color.hsl = action.payload.hsl;
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
  updateLocaleRgbValueOfColorModel,
  setIsFormDisplayed,
  setLocked,
} = colorSlice.actions;
export default colorSlice.reducer;

//FIXME: currently FormGenerators are bloat code. They do not reduce many features
// Hex color and Hsv color is not being used and is being calculated from the rgb color values
// HSV does not do anything because hsv cannot be used as a css color unlike hsl

// Currently fetchColorModel needs testing
/**
 * This is because the plan is to fetch the color model only when switching between color Types.
 * But since there currently is only rgb then we cannot switch between so it cannot be tested. This maintains
 * the responsiveness of the client and doesnt overload the server when being called a million times if user
 * plays with slider
 */
