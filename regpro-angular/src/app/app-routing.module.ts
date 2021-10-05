import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { BaseLayoutComponent } from "./components/layout/base-layout.component";
import { DailyTaskComponent } from "./components/daily-task/daily-task.component";
import { LoginComponent } from "./components/login/login.component";
//import { AuthGuard } from "./guards/auth.guard";
import { RegistrationModule } from "./features/registration/registration.module";
import { SideNavigationComponent } from "./components/layout/side-navigation/side-navigation.component";
// import { ManagementModule } from "./features/management/management.module";
import { NgxPermissionsGuard } from 'ngx-permissions';

export const routes: Routes = [
  // Main redirect
  { path: "", redirectTo: "/regpro", pathMatch: "full" },

  { path: "login", component: LoginComponent },

  {
    path: "regpro",
    component: BaseLayoutComponent,
    //canActivate: [AuthGuard],
    children: [
      {
        path: "registro",
        //canActivate: [AuthGuard],
        loadChildren: () => RegistrationModule
      },
      // {
      //   path:"gestion",
      //   canActivate: [AuthGuard],
      //   loadChildren: () => ManagementModule
      // }
    ],
  },

  // Handle all other routes
  // { path: '**', redirectTo: 'starterview' }
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)],
})
export class AppRoutingModule { }
