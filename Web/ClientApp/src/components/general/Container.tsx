import React from "react";

type Props = { children: React.ReactChild };

export default function Container(props: Props) {
  return <div className="mx-0 sm:mx-2">{props.children}</div>;
}
