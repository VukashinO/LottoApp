import {RouterConfiguration, Router } from 'aurelia-router';
import { PLATFORM } from "aurelia-framework";
import { AuthorizeStep } from './pipeline-steps/authorizeStep'; 

export class App {
  router: Router;

  configureRouter(config: RouterConfiguration, router: Router): void {
    this.router = router;
    config.title = 'Aurelia';
    config.addAuthorizeStep(AuthorizeStep)
    config.map([
      { route: '',           name: 'landing',      moduleId: PLATFORM.moduleName('landing/landing') },
      { route: 'logIn',      name: 'logIn',        moduleId: PLATFORM.moduleName('logIn/logIn') },
      { route: 'ticket',     name: 'ticket',       moduleId: PLATFORM.moduleName('ticket/ticket'),  settings:{ isAuth : true } },
      { route: 'admin',      name: 'admin',        moduleId: PLATFORM.moduleName('admin/admin'),    settings:{ isAdmin : true } }
    ]);
  }
}




  







