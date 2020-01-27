import { BrowserModule } from '@angular/platform-browser';
import { LOCALE_ID,NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule, NgbPaginationConfig } from '@ng-bootstrap/ng-bootstrap';

//Rutas
import { APP_ROUTES } from './app.routes';

//Modulos
import { PagesModule } from './pages/pages.module';

//Comopnentes 
import { AppComponent } from './app.component';

import { LoginComponent } from './login/login.component';
import { NopagefoundComponent } from './nopagefound/nopagefound.component';

import { AuthGuardService } from 'src/services/general/auth-guard.service';
import { AuthInterceptorService } from 'src/services/general/auth-interceptor.service';

import localeEs from '@angular/common/locales/es';
import { registerLocaleData } from '@angular/common';
import { FormrootComponent } from './formroot/formroot.component';
registerLocaleData(localeEs);

@NgModule({
  declarations: [
    LoginComponent,
    NopagefoundComponent,    
    AppComponent,
    FormrootComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    APP_ROUTES,
    PagesModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule
        
  ],
  exports: [
    NgbModule
  ],
  providers: [
    AuthGuardService,    
    NgbPaginationConfig,    
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    }, { provide: LOCALE_ID, useValue: 'es' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
