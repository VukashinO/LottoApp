import { NavigationInstruction, Next,PipelineStep, Redirect } from 'aurelia-router';
import { ApiService } from '../services/api-service';
import { inject } from 'aurelia-framework';

@inject(ApiService)
export class AuthorizeStep implements PipelineStep {
    
    constructor(private service: ApiService){};
    public run(navigationInstruction: NavigationInstruction, next: Next): Promise<any> {
      if (navigationInstruction.getAllInstructions().some(i => i.config.settings.isAuth )) {
        if (!this.service.isAuth) {
          return next.cancel(new Redirect('logIn'));
        }
      }
      if (navigationInstruction.getAllInstructions().some(i => i.config.settings.isAdmin )) {
        if (!this.service.isAdmin) {
          return next.cancel(new Redirect('ticket'));
        }
      }
      return next();
    }
  }