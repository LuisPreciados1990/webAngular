"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var login_component_1 = require("./login/login.component");
var nopagefound_component_1 = require("./nopagefound/nopagefound.component");
var formroot_component_1 = require("./formroot/formroot.component");
var appRoutes = [
    { path: 'login', component: login_component_1.LoginComponent },
    { path: 'fRoot', component: formroot_component_1.FormrootComponent },
    { path: '**', component: nopagefound_component_1.NopagefoundComponent }
];
exports.APP_ROUTES = router_1.RouterModule.forRoot(appRoutes, { useHash: true });
//# sourceMappingURL=app.routes.js.map