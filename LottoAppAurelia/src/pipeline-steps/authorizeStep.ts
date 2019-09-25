import {
  NavigationInstruction,
  Next,
  PipelineStep,
  Redirect
} from "aurelia-router";
import { AuthToken } from "./../auth/userAuthorization/auth-token";

export class AuthorizeStep implements PipelineStep {
  constructor() {}

  public run(
    navigationInstruction: NavigationInstruction,
    next: Next
  ): Promise<any> {
    if (
      navigationInstruction
        .getAllInstructions()
        .some(i => i.config.settings.isAuth)
    ) {
      if (!localStorage.getItem(AuthToken.token)) {
        return next.cancel(new Redirect("logIn"));
      }
    }
    if (
      navigationInstruction
        .getAllInstructions()
        .some(i => i.config.settings.isAdmin)
    ) {
      if (!localStorage.getItem(AuthToken.admin)) {
        return next.cancel(new Redirect("ticket"));
      }
    }
    return next();
  }
}
