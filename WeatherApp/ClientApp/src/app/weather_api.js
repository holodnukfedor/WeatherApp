"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.WEATHER_API_URL = void 0;
var core_1 = require("@angular/core");
var environment_1 = require("../environments/environment");
exports.WEATHER_API_URL = new core_1.InjectionToken('weather api url', {
    providedIn: 'root',
    factory: function () { return environment_1.environment.weatherApi; },
});
//# sourceMappingURL=weather_api.js.map