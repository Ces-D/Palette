import { useState } from "react";

export default function RgbForm() {
  const [red, setRed] = useState(0);
  const [green, setGreen] = useState(0);
  const [blue, setBlue] = useState(0);

  // TODO: add plus and minus to the nuber values
  // TODO: add validation for allowing correct numbers: below 255
  // TODO: create the scrollable preview for the value of r,g,b

  return (
    <div>
      <section>
        <p className="inline-block w-10">Red</p>
        <input
          className="inline-block"
          type="number"
          value={red}
          onChange={(e) => setRed(e.target.valueAsNumber)}
        />
      </section>
      <section>
        <p className="inline-block w-10">Green</p>
        <input
          className="inline-block"
          type="number"
          value={green}
          onChange={(e) => setGreen(e.target.valueAsNumber)}
        />
      </section>
      <section>
        <p className="inline-block w-10">Blue</p>
        <input
          className="inline-block"
          type="number"
          value={blue}
          onChange={(e) => setBlue(e.target.valueAsNumber)}
        />
      </section>
    </div>
  );
}
