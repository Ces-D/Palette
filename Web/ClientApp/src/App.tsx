import { Route, Routes } from "react-router";
import { Provider } from "react-redux";
import Home from "./components/routes/Home";
import Container from "./components/general/Container";
import { appStore } from "./store/configureStore";
import "./custom.css";

export default function App() {
  return (
    <Provider store={appStore}>
      <Routes>
        <Route path="/" element={<Container />}>
          <Route index element={<Home />} />
        </Route>
      </Routes>
    </Provider>
  );
}
