import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RegistrationMain } from "./registration.main";
import { RouterModule } from "@angular/router";
import { RegistrationRoutingModule, routingRegistrationComponent } from "./registration.routing";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ComponentsModule } from "../../components/components.module";
import { NgSelectModule } from "@ng-select/ng-select";
import { NgxSpinnerModule } from "ngx-spinner";
import { TableModule } from 'ngx-easy-table';

import { Utilfunctions } from "src/app/services/util-functions.service";
import { UtilRegistroService } from "src/app/services/util-registro.service";
import { RegProMaestroService } from "src/app/services/tbl-regpro-maestro/tbl-regpro-maestro.service";
import { RegionService } from "src/app/services/region/region.service";
import { ProvinciaService } from "src/app/services/provincia/provincia.service";
import { DistritoService } from "src/app/services/distrito/distrito.service";
import { TblRegproSolicitudService } from "src/app/services/tbl-regpro-solicitud/tbl-regpro-solicitud.service";
import { RegProProgramaService } from "src/app/services/tbl-regpro-programa/tbl-regpro-programa.service";

@NgModule({
  declarations: [
    RegistrationMain,
    routingRegistrationComponent
  ],
  imports: [
    ComponentsModule,
    CommonModule,
    RegistrationRoutingModule,
    FormsModule,
    NgSelectModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
    TableModule
  ],
  providers: [
    Utilfunctions,
    UtilRegistroService,
    RegProMaestroService,
    RegionService,
    ProvinciaService,
    DistritoService,
    TblRegproSolicitudService,
    RegProProgramaService
  ],
  exports: [routingRegistrationComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class RegistrationModule {}
