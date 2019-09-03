import { ApiService } from '../services/api-service';
import { Router } from 'aurelia-router';
import { inject } from 'aurelia-framework';
import { AuthToken } from '../authToken/auth-token';


@inject(ApiService, Router)
export class LogIn {
    public authorize: IAuthorizeModel;
    public logIn: ILogInViewModel;
    public error: string;
    constructor(private service: ApiService, private route: Router, public isAuth: boolean) {}
 
    public async onSubmit() {

    this.authorize =  await this.service.logIn(this.logIn);
    localStorage.setItem(AuthToken.token, this.authorize.token);
    if(this.authorize.isAdmin)
    {
        this.service.isAdmin = true;
    }
    this.service.isAuth = true;
    this.route.navigateToRoute('ticket');
    }
}
