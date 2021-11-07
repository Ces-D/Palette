import { NavLink } from "react-router-dom";
import LoginIcon from "./icons/LoginIcon";
import PencilIcon from "./icons/PencilIcon";
import SearchIcon from "./icons/SearchIcon";

export default function Header() {
  const homeUrl = "/";
  const exploreUrl = "/explore";
  const loginUrl = "/login";

  const mobileHeader = (
    <>
      <button className="mr-6 sm:hidden icon-button bg-gray-100 hover:bg-gray-400">
        <NavLink exact to={homeUrl}>
          <PencilIcon />
        </NavLink>
      </button>
      <button className="mr-6 sm:hidden icon-button bg-gray-100 hover:bg-gray-400">
        <NavLink exact to={exploreUrl}>
          <SearchIcon />
        </NavLink>
      </button>
      <button className="sm:hidden icon-button bg-gray-100 hover:bg-gray-400">
        <NavLink exact to={loginUrl}>
          <LoginIcon />
        </NavLink>
      </button>
    </>
  );

  const laptopHeader = (
    <>
      <h2 className="text-lg hidden sm:inline-block sm:mr-12">
        <NavLink exact activeClassName="underline" className="text-xl" to={homeUrl}>
          Create
        </NavLink>
      </h2>
      <h2 className="text-lg hidden sm:inline-block mr-6 sm:mr-12">
        <NavLink activeClassName="underline" className="text-xl" to={exploreUrl}>
          Explore
        </NavLink>
      </h2>
      <h2 className="text-lg hidden sm:inline-block">
        <NavLink activeClassName="underline" className="text-xl" to={loginUrl}>
          Login
        </NavLink>
      </h2>
    </>
  );

  return (
    <header className="max-w-4xl m-auto h-20 flex justify-between items-center px-1 sm:px-0">
      <h1 className="text-3xl font-bold">Palette</h1>
      <section className="w-1/2 text-right">
        {mobileHeader}
        {laptopHeader}
      </section>
    </header>
  );
}
