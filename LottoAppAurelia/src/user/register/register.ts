import { ApiService } from "services/api-service";
import { inject, observable } from "aurelia-framework";
import { Router } from "aurelia-router";
import { AuthToken } from "../userAuthorization/auth-token";

@inject(ApiService, Router)
export class Register {
  public register: IRegisterViewModel;
  public authorize: IAuthorizeModel;
  public checkIf18: boolean;
  @observable public ageValue: string;
  constructor(private service: ApiService, private route: Router) {}

  ageValueChanged(newValue) {
    this.getAge(newValue);
  }

  public async onRegister() {
    this.authorize = await this.service.register(this.register);
    localStorage.setItem(AuthToken.token, this.authorize.token);
    this.service.isAuth = true;
    this.register = null;
    this.route.navigateToRoute("ticket");
  }

  public onAlreadyMember() {
    this.route.navigateToRoute("logIn");
    return false;
  }

  private getAge(dateString) {
    let today = new Date();
    let birthDate = new Date(dateString);
    let age = today.getFullYear() - birthDate.getFullYear();
    let m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }

    if (age < 18) {
      this.checkIf18 = true;
      return;
    }

    this.checkIf18 = false;
    return age;
  }
}
