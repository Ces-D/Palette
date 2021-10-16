import { NavLink } from "react-router-dom";

export default function Header() {
  return (
    <header className="max-w-4xl m-auto h-20 flex justify-between items-center">
      <h1 className="text-3xl font-bold">Palette</h1>
      <section className="flex justify-around w-1/2">
        <h2 className="text-lg">
          <NavLink exact activeClassName="underline" className="text-xl" to="/">
            Create
          </NavLink>
        </h2>
        <h2 className="text-lg">
          <NavLink activeClassName="underline" className="text-xl" to="/explore">
            Explore
          </NavLink>
        </h2>
        <h2 className="text-lg">
          <NavLink activeClassName="underline" className="text-xl" to="/login">
            Login
          </NavLink>
        </h2>
      </section>
    </header>
  );
}
