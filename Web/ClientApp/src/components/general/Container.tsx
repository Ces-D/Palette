import { Outlet } from "react-router-dom";
import Header from "./Header";
import Sidebar from "./Sidebar";

export default function Container() {
  return (
    <>
      <Header />
      <Sidebar>
        <Outlet />
      </Sidebar>
    </>
  );
}
