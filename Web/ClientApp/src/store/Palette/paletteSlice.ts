import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export interface Palette {
  id: string | null;
  author: string | "anonymous";
  colorIds: string[];
}

const initialPaletteState: Palette = {
  id: null,
  author: "anonymous",
  colorIds: [],
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
  },
});

export default paletteSlice.reducer;