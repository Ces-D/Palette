import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export interface Palette {
  id: string | null;
  author: string | "anonymous";
  colorIds: string[];
  error: { status: boolean; message: string | null };
}

const initialPaletteState: Palette = {
  id: null,
  author: "anonymous",
  colorIds: [],
  error: { status: false, message: null },
};

const paletteSlice = createSlice({
  name: "palette",
  initialState: initialPaletteState,
  reducers: {
    addColor(state, action: PayloadAction<{ colorId: string }>) {
      state.colorIds.push(action.payload.colorId);
    },
    removeColor(state, action: PayloadAction<{ colorId: string }>) {
      state.colorIds.filter((colorId) => colorId !== action.payload.colorId);
    },
    changeAuthor(state, action: PayloadAction<{ author: string }>) {
      state.author = action.payload.author;
    },
    setColorError(state, action: PayloadAction<{ errorMsg: string }>) {
      state.error.status = true;
      state.error.message = action.payload.errorMsg;
    },
  },
});

export const { addColor, removeColor, changeAuthor, setColorError } =
  paletteSlice.actions;
export default paletteSlice.reducer;
