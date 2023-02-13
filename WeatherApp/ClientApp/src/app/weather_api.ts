import { InjectionToken } from "@angular/core";
import { environment } from "../environments/environment";

export type WeatherApiUrl = typeof environment.weatherApi;

export const WEATHER_API_URL = new InjectionToken<WeatherApiUrl>('weather api url', {
    providedIn: 'root',
    factory: () => environment.weatherApi,
});