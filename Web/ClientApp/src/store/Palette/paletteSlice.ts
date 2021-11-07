import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export interface Palette {
  id: string | null;
  author: string | "anonymous";
  error: { status: boolean; message: string | null };
}

const initialPaletteState: Palette = {
  id: null,
  author: "anonymous",
  error: { status: false, message: null },
};

const paletteSlice = createSlice({
  name: "palette",
  initialState: initialPaletteState,
  reducers: {
    changeAuthor(state, action: PayloadAction<{ author: string }>) {
      state.author = action.payload.author;
    },
    setColorError(state, action: PayloadAction<{ errorMsg: string }>) {
      state.error.status = true;
      state.error.message = action.payload.errorMsg;
    },
  },
});

export const { changeAuthor, setColorError } = paletteSlice.actions;
export default paletteSlice.reducer;

// TODO: Add a method for adding the colors as a passed in parameters (Color[] colors) ; requires an api endpoint
// This would be for whenever we want to save a users palette