import es from '@angular/common/locales/es';
import { registerLocaleData, DatePipe } from '@angular/common';
registerLocaleData(es);

var dp = new DatePipe(navigator.language);
var format = "yyyy-MM-dd";

export const environment = {
  production: true,
  eIva: 12,
  eUsuario: "ADMIN",
  eNombreUsuario: "Administrador",
  eFechaSys: dp.transform(new Date(), format),
  eConsFinal: "C99999",
  eNomcia: "EMPRESA DEMO"
};
