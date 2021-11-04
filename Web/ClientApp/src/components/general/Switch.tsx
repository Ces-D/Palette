import React from "react";

/**
 * @property searchValue: term that is being searched from from among the value props of children
 * @property children: and array of child components which will be searched
 */
type Props = { searchValue: string; children: React.ReactElement[] };

/**
 * @returns The first child component whose value matches the searchValue
 */
export default function Switch(props: Props) {
  return (
    props.children.find((child) => child.props.value === props.searchValue) || (
      <div>Could Not Find</div>
    )
  );
}
