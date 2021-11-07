import { NavLink } from "react-router-dom";

export default function Header() {
  return (
    <header className="max-w-4xl m-auto h-20 flex justify-between items-center px-1 sm:px-0">
      <h1 className="text-3xl font-bold">Palette</h1>
      <section className="w-1/2 text-right">
        <h2 className="text-lg sm:inline-block sm:mr-12">
          <NavLink exact activeClassName="underline" className="text-xl" to="/">
            Create
          </NavLink>
        </h2>
        <h2 className="text-lg sm:inline-block sm:mr-12">
          <NavLink activeClassName="underline" className="text-xl" to="/explore">
            Explore
          </NavLink>
        </h2>
        <h2 className="text-lg sm:inline-block">
          <NavLink activeClassName="underline" className="text-xl" to="/login">
            Login
          </NavLink>
        </h2>
      </section>
    </header>
  );
}
