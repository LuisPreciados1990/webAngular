import { RouterModule, Routes } from "@angular/router";
import { PagesComponent } from "./pages.component";
import { HomeComponent } from "../home/home.component";

import { Web01f110Component } from "./CNT/web01f110/web01f110.component";
import { Web01f110EditComponent } from "./CNT/web01f110/web01f110-edit.component";

import { Web01f120Component } from "./CNT/web01f120/web01f120.component";

import { Web01f130Component } from "./CNT/web01f130/web01f130.component";
import { Web01f130EditComponent } from "./CNT/web01f130/web01f130-edit.component";

import { Web01f180Component } from "./CNT/web01f180/web01f180.component";
import { Web01f180EditComponent } from "./CNT/web01f180/web01f180-edit.component";

import { Web02f110Component } from "./BAN/web02f110/web02f110.component";
import { Web02f110EditComponent } from "./BAN/web02f110/web02f110-edit.component";

import { Web03f120Component } from "./INV/web03f120/web03f120.component";
import { Web03f120EditComponent } from "./INV/web03f120/web03f120-edit.component";

const pagesRoutes: Routes = [
  {    
    path: '',
    component: PagesComponent,
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'plan.cuenta.root', component: Web01f110Component },
      { path: 'plan.cuenta.root/edit/:id', component: Web01f110EditComponent },

      { path: 'web01f120', component: Web01f120Component },

      { path: 'comprobantes.contables.root', component: Web01f130Component },
      { path: 'comprobantes.contables.root/edit/:id', component: Web01f130EditComponent },

      { path: 'centro.costo.contable.root', component: Web01f180Component },
      { path: 'centro.costo.contable.root/edit/:id', component: Web01f180EditComponent },

      { path: 'bancos.root', component: Web02f110Component },
      { path: 'bancos.root/edit/:id', component: Web02f110EditComponent },

      { path: 'productos.root', component: Web03f120Component },
      { path: 'productos.root/edit/:id', component: Web03f120EditComponent },

      { path: '', redirectTo: '/home', pathMatch: 'full' }
    ]   
  }
];

export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);
