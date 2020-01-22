"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var pages_component_1 = require("./pages.component");
var home_component_1 = require("../home/home.component");
var web01f110_component_1 = require("./CNT/web01f110/web01f110.component");
var web01f110_edit_component_1 = require("./CNT/web01f110/web01f110-edit.component");
var web01f120_component_1 = require("./CNT/web01f120/web01f120.component");
var web01f130_component_1 = require("./CNT/web01f130/web01f130.component");
var web01f130_edit_component_1 = require("./CNT/web01f130/web01f130-edit.component");
var web01f180_component_1 = require("./CNT/web01f180/web01f180.component");
var web01f180_edit_component_1 = require("./CNT/web01f180/web01f180-edit.component");
var web02f110_component_1 = require("./BAN/web02f110/web02f110.component");
var web02f110_edit_component_1 = require("./BAN/web02f110/web02f110-edit.component");
var web03f120_component_1 = require("./INV/web03f120/web03f120.component");
var web03f120_edit_component_1 = require("./INV/web03f120/web03f120-edit.component");
var pagesRoutes = [
    {
        path: '',
        component: pages_component_1.PagesComponent,
        children: [
            { path: 'home', component: home_component_1.HomeComponent },
            { path: 'plan.cuenta.root', component: web01f110_component_1.Web01f110Component },
            { path: 'plan.cuenta.root/edit/:id', component: web01f110_edit_component_1.Web01f110EditComponent },
            { path: 'web01f120', component: web01f120_component_1.Web01f120Component },
            { path: 'comprobantes.contables.root', component: web01f130_component_1.Web01f130Component },
            { path: 'comprobantes.contables.root/edit/:id', component: web01f130_edit_component_1.Web01f130EditComponent },
            { path: 'centro.costo.contable.root', component: web01f180_component_1.Web01f180Component },
            { path: 'centro.costo.contable.root/edit/:id', component: web01f180_edit_component_1.Web01f180EditComponent },
            { path: 'bancos.root', component: web02f110_component_1.Web02f110Component },
            { path: 'bancos.root/edit/:id', component: web02f110_edit_component_1.Web02f110EditComponent },
            { path: 'productos.root', component: web03f120_component_1.Web03f120Component },
            { path: 'productos.root/edit/:id', component: web03f120_edit_component_1.Web03f120EditComponent },
            { path: '', redirectTo: '/home', pathMatch: 'full' }
        ]
    }
];
exports.PAGES_ROUTES = router_1.RouterModule.forChild(pagesRoutes);
//# sourceMappingURL=pages.routes.js.map