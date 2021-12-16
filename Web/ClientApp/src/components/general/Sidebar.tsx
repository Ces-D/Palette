import { Anchor } from "@mantine/core";
import { Link } from "react-router-dom";
import { v4 } from "uuid";

interface SidebarProps {
  children: React.ReactChild;
}

interface SideBarRoute {
  path: string;
  label: string;
}

export default function Sidebar(props: SidebarProps) {
  const sideBarRoutes: SideBarRoute[] = [
    {
      path: "/",
      label: "Design",
    },
    {
      path: "/quadratic",
      label: "Quadratic",
    },
  ];

  return (
    <div className="flex flex-row">
      <nav className="sticky top-0 text-center py-5 px-3 border-r border-solid border-gray-400 min-h-half-screen">
        <ul>
          {sideBarRoutes.map((route) => (
            <li key={v4()} className="p-2">
              <Anchor component={Link} to={route.path}>
                {route.label}
              </Anchor>
            </li>
          ))}
        </ul>
      </nav>
      {props.children}
    </div>
  );
}
