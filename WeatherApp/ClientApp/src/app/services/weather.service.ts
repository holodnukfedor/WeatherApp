import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { WeatherState } from "../models/weather-state";
import { WeatherApiUrl, WEATHER_API_URL } from "../weather_api";

@Injectable({
    providedIn: 'root'
})
export class WeatherService {
    constructor(
        private readonly http: HttpClient,
        @Inject(WEATHER_API_URL) private readonly weatherApiUrl: WeatherApiUrl
    ) {
    }

    public getCurrent(zipCode: string): Observable<WeatherState> {
        return this.http.get<WeatherState>(`${this.weatherApiUrl}/weather?zipCode=${zipCode}`);
    }
}