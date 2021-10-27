import { configureStore } from "@reduxjs/toolkit";
import PaletteReducer from "./Palette/paletteSlice";
import ColorReducer from "./Color/colorSlice";

export const appStore = configureStore({
  reducer: {
    palette: PaletteReducer,
    colors: ColorReducer,
  },
});

// see - https://redux.js.org/usage/usage-with-typescript
// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof appStore.getState>;
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof appStore.dispatch;
