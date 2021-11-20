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

export enum BuildColorType {
  Rgb = 0,
  Hsl = 1,
}

/**
 * @summary The view model for the api POST request for ColorController
 */
export type ColorControllerGenerateColorModel = {
  colorType: BuildColorType;
  color: string;
  id: string;
};

export type ColorState = {
  locked: boolean;
  isFormDisplayed: boolean;
  color: Color;
  activeColorType: BuildColorType;
};

export interface Color extends ApiColorModel {}

export interface ApiColorModel {
  id: string;
  rgb: Rgb;
  hsl: Hsl;
}
