import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { RegistrationMain } from "./registration.main";

import { CreationRequestPage } from "./pages/creation-request/creation-request.component";
import { ModificationRequestPage } from "./pages/modification-request/modification-request.component";
import { RenovationRequestPage } from "./pages/renovation-request/renovation-request.component";
import { ClosingRequestPage } from "./pages/closing-request/closing-request.component";

import { SharedRequestPage } from "./pages/shared-request/shared-request.component";
import { RequestIdentificationComponent } from "./pages/shared-request/components/request-identification/request-identification.component";
import { RequestLocationComponent } from "./pages/shared-request/components/request-location/request-location.component";
import { RequestSupportDocumentationComponent } from "./pages/shared-request/components/request-support-documentation/request-support-documentation.component";
import { RequestComplementaryComponent } from "./pages/shared-request/components/request-complementary/request-complementary.component";

export const ROUTES: Routes = [
  {
    path: "",
    component: RegistrationMain,
    children: [
      {
        path: 'v-ugl-sol-creacion',
        component: CreationRequestPage,
      },
      {
        path: "v-ugl-sol-modificacion",
        component: ModificationRequestPage,
      },
      {
        path: "v-ugl-sol-renovacion",
        component: RenovationRequestPage
      },
      {
        path: "v-ugl-sol-cierre",
        component: ClosingRequestPage
      },
    ],
  },
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(ROUTES, { relativeLinkResolution: 'legacy' })],
})
export class RegistrationRoutingModule {}

export const routingRegistrationComponent =
[
  CreationRequestPage,
  ModificationRequestPage,
  RenovationRequestPage,
  ClosingRequestPage,
  //componentes compartidos
  SharedRequestPage,
  RequestIdentificationComponent,
  RequestLocationComponent,
  RequestSupportDocumentationComponent,
  RequestComplementaryComponent
]
