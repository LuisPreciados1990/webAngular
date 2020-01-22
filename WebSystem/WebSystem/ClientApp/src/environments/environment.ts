// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

import es from '@angular/common/locales/es';
import { registerLocaleData, DatePipe } from '@angular/common';
registerLocaleData(es);

var dp = new DatePipe(navigator.language);
var format = "yyyy-MM-dd";

export const environment = {
  production: true,
  eIva: 12,
  eUsuario: "ADMIN",
  eNombreUsuario:"Administrador",
  eFechaSys: dp.transform(new Date(), format),
  eConsFinal: "C99999",
  eNomcia: "EMPRESA DEMO"
};

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
