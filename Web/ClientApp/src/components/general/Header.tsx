import { NavLink } from "react-router-dom";
import LoginIcon from "./icons/LoginIcon";
import PencilIcon from "./icons/PencilIcon";
import SearchIcon from "./icons/SearchIcon";
import { Button } from "@mantine/core";

export default function Header() {
  const homeUrl = "/";
  const exploreUrl = "/explore";
  const loginUrl = "/login";

  const mobileHeader = (
    <nav className="block sm:hidden">
      <Button color="dark" variant="link" className="mr-5">
        <NavLink
          className={(navData) =>
            navData.isActive ? "stroke-2 text-red-500" : "stroke-1"
          }
          to={homeUrl}
        >
          <PencilIcon />
        </NavLink>
      </Button>
      <Button color="dark" variant="link" className="mr-5">
        <NavLink
          className={(navData) =>
            navData.isActive ? "stroke-2 text-red-500" : "stroke-1"
          }
          to={exploreUrl}
        >
          <SearchIcon />
        </NavLink>
      </Button>
      <Button color="dark" variant="link" className="mr-5">
        <NavLink
          className={(navData) =>
            navData.isActive ? "stroke-2 text-red-500" : "stroke-1"
          }
          to={loginUrl}
        >
          <LoginIcon />
        </NavLink>
      </Button>
    </nav>
  );

  const laptopHeader = (
    <nav className="hidden sm:block">
      <h2 className="text-lg hidden sm:inline-block sm:mr-12">
        <NavLink
          className={(navData) => (navData.isActive ? "underline text-red-500 text-xl" : "")}
          to={homeUrl}
        >
          Create
        </NavLink>
      </h2>
      <h2 className="text-lg hidden sm:inline-block mr-6 sm:mr-12">
        <NavLink
          className={(navData) => (navData.isActive ? "underline text-red-500 text-xl" : "")}
          to={exploreUrl}
        >
          Explore
        </NavLink>
      </h2>
      <h2 className="text-lg hidden sm:inline-block">
        <NavLink
          className={(navData) => (navData.isActive ? "underline text-red-500 text-xl" : "")}
          to={loginUrl}
        >
          Login
        </NavLink>
      </h2>
    </nav>
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
