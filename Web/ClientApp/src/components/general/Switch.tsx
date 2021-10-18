import React from "react";

type Props = { searchValue: string; children: React.ReactElement[] };
export default function Switch(props: Props) {
  return (
    props.children.find((child) => child.props.value === props.searchValue) || (
      <div>Could Not Find</div>
    )
  );
}
