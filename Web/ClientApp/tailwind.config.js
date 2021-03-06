// tailwind.config.js
module.exports = {
  purge: ["./src/**/*.{js,jsx,ts,tsx}", "./public/index.html"],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
      height: (theme) => ({
        88: "22rem",
      }),
      minHeight: (theme) => ({
        56: "14rem",
        "half-screen": "75vh",
      }),
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
};
