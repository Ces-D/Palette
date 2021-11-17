/**
 * @summary Model for the Rgb Color Model
 */
export interface Rgb {
  color: string;
  red: number;
  green: number;
  blue: number;
}

// /**
//  * @summary Model for the Hex Color Model
//  */
// export interface Hex {
//   color: string;
// }

// /**
//  * @summary Model for the Hsv Color Model
//  */
// export interface Hsv {
//   color: string;
//   hue: number;
//   saturation: number;
//   hValue: number;
// }

/**
 * @summary Model for the Hsl Color Model
 */
export interface Hsl {
  color: string;
  hue: number;
  saturation: number;
  lightness: number;
}

export type ColorType = "rgb" | "hsl";

/**
 * @summary The view model for the api POST request for ColorController
 */
export type ColorControllerGenerateColorModel = {
  ColorType: ColorType | string;
  ColorValue: string;
  ColorId: string;
};

export type ColorState = {
  locked: boolean;
  isFormDisplayed: boolean;
  color: Color;
};
export interface Color {
  id: string;
  rgb: Rgb;
  hsl: Hsl;
}
