import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { SigninComponent } from "./Core/signin/signin.component";
import { DefaultCompComponent } from "./Components/default-comp/default-comp.component";

const routes: Routes = [
  {
    path: "sign-in",
    component: SigninComponent,
  },
  {
    path: "default",
    component: DefaultCompComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
