import { createSlice, createAsyncThunk, PayloadAction } from "@reduxjs/toolkit";
import axios from "axios";
import {
  ApiColorModel,
  BuildColorType,
  ColorControllerGenerateColorModel,
  ColorState,
} from "./types";

const initialColorState: ColorState[] = [];

/**
 * @method POST
 * @summary This fetches a new color model calculated from a specific color type string
 * @see  {ColorControllerGenerateColorModel}
 */
export const fetchColorModel = createAsyncThunk(
  "color/fetchColorModel",
  async (requestBody: ColorControllerGenerateColorModel): Promise<ApiColorModel> => {
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
  async (): Promise<ApiColorModel> => {
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
    setActiveColorType(
      state,
      action: PayloadAction<{ id: string; colorType: BuildColorType }>
    ) {
      const updateIndex = state.findIndex(
        (colorState) => colorState.color.id === action.payload.id
      );
      state[updateIndex].activeColorType = action.payload.colorType;
      return state;
    },
    removeColorModel(state, action: PayloadAction<{ id: string }>) {
      return state.filter((colorState) => colorState.color.id !== action.payload.id);
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
        state.push({
          locked: false,
          isFormDisplayed: false,
          activeColorType: 0,
          color: { ...action.payload },
        });
      });
  },
});

export const { removeColorModel, setIsFormDisplayed, setLocked, setActiveColorType } =
  colorSlice.actions;
export default colorSlice.reducer;
