import { Route } from "react-router";
import { Provider } from "react-redux";
import Layout from "../components/Layout";
import Home from "../components/routes/Home";
import { appStore } from "../store/configureStore";
import "./custom.css";

export default function App() {
  return (
    <Provider store={appStore}>
      <Layout>
        <Route exact path="/" component={Home} />
      </Layout>
    </Provider>
  );
}