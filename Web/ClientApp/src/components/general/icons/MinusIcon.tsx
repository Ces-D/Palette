type Props = {
  class?: string;
};

export default function MinusIcon(props: Props) {
  return (
    <svg
      xmlns="http://www.w3.org/2000/svg"
      className={`${props.class || ""} icon`}
      fill="none"
      viewBox="0 0 24 24"
      stroke="currentColor"
    >
      <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M20 12H4" />
    </svg>
  );
}
