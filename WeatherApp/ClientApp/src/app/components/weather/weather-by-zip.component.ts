import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Observable, pipe, of, catchError, map, tap } from 'rxjs';
import { HttpResult } from '../../models/http-result';
import { WeatherState } from '../../models/weather-state';
import { WeatherService } from '../../services/weather.service';

@Component({
    selector: 'weather-by-zip',
    templateUrl: './weather-by-zip.component.html',
})
export class WeatherByZipComponent {
    private weatherForm: FormGroup;
    public get zipCode() { return this.weatherForm.get('zipCode'); }
    public weatherStateRequestResult$!: Observable<HttpResult<WeatherState>>;
    public isLoading: boolean;

    constructor(
        private readonly weatherService: WeatherService,
        formBuilder: FormBuilder
    ) {
        this.weatherForm = formBuilder.group({
            zipCode: new FormControl({ value: '', disabled: this.isLoading })
        });
    }

    public showCurrentWeather() {
        this.isLoading = true;
        this.weatherStateRequestResult$ = this.weatherService.getCurrent(this.zipCode.value).pipe(
            tap(() => {
                this.isLoading = false;
            }),
            map((state) => {
                return ({ isSuccess: true, data: state });
            }),
            catchError((error: HttpErrorResponse) => {
                this.isLoading = false;

                if (error.status === 404) {
                    return of({ isSuccess: false, errorMessage: "City not found by zip code." });
                }

                if (error.status == 400) {
                    return of({ isSuccess: false, errorMessage: "Incorrect query." });
                }

                return of({ isSuccess: false, errorMessage: "Internal server error, try again later." });
            })
        );
    }
}
