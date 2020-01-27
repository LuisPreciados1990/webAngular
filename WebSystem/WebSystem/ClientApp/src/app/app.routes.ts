import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { NopagefoundComponent } from "./nopagefound/nopagefound.component";
import { FormrootComponent } from "./formroot/formroot.component";

const appRoutes: Routes = [  
  { path: 'login', component: LoginComponent },
  { path: 'fRoot', component: FormrootComponent },    
  { path: '**', component: NopagefoundComponent }
]

export const APP_ROUTES = RouterModule.forRoot(appRoutes, {useHash:true});
