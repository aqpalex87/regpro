import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormControl, Validators } from "@angular/forms";
import { take } from "rxjs/operators";
import { RequestDataModel } from "src/app/models/requestdata.model";
import { UtilRegistroService } from "src/app/services/util-registro.service";
import { RegProMaestroService } from "src/app/services/tbl-regpro-maestro/tbl-regpro-maestro.service";
import { RegProProgramaService } from "src/app/services/tbl-regpro-programa/tbl-regpro-programa.service";
import Swal from 'sweetalert2'

@Component({
  selector: "rgp-request-identification",
  templateUrl: "./request-identification.component.html",
  styleUrls: ["./request-identification.component.css"],
})
export class RequestIdentificationComponent implements OnInit {

  requestData: RequestDataModel;
  @Input() formRequestIdentification: FormGroup;
  @Input() flagSearch: boolean;
  @Input() flagReadOnlyControls: boolean;
  @Input() flagCheckEdit: boolean;

  public flagReadOnlyName: boolean = true
  public flagReadOnlyGestion: boolean = true
  public flagReadOnlyPrograma: boolean = true
  public flagReadOnlyDependencia: boolean = true
  public flagReadOnlyGestora: boolean = true

  public flagDep: number = 0
  public flagEntGes: number = 0

  public datosUser: any

  constructor(
    private _fb: FormBuilder,
    private utilRegistroService: UtilRegistroService,
    private regProMaestroService: RegProMaestroService,
    private regProProgramaService: RegProProgramaService
  ) {
     this.requestData = new RequestDataModel()
  }

  ngOnInit() {
    this.datosUser = JSON.parse(localStorage.getItem('datosUser'))
    this.loadData();
    this.utilRegistroService.changeProgramData.subscribe(isProgramData => {
      this.formRequestIdentification.get('name').setValue(isProgramData.cNomprog)
      this.formRequestIdentification.get('typeManagement').setValue(isProgramData.nIdTipgest)
      this.formRequestIdentification.get('typeProgram').setValue(isProgramData.nIdTipprog)
      this.flagDep = isProgramData.nIdTipdepe
      this.flagEntGes = isProgramData.nIdTipeges
      this.tipogestionChanged(isProgramData.nIdTipgest, 'EDIT')
    });
  }

  loadData() {
    //gestion
    this.regProMaestroService
      .getAllByCodGrop('3')
      .subscribe((data) => {
        let datos = data['data']
        this.requestData.typeManagements = datos
      }
    );
    //programas
    this.regProMaestroService
      .getAllByCodGrop('1')
      .subscribe((data) => {
        let datos = data['data']
        this.requestData.typePrograms = datos
      }
    );
  }

  //dependencias
  tipogestionChanged(departmentId: number, flag: string) {
    this.regProMaestroService
      .getAllByCodGropAndIdMaestropadre('4',departmentId)
      .subscribe((data) => {
        let datos = data['data']
        if( datos.length > 0 ){
          this.requestData.typeDependencies = datos
          this.requestData.typeManagingEntitys = []
          this.formRequestIdentification.get('typeManagingEntity').setValue(null)
          if( flag === 'EDIT' ){
            this.formRequestIdentification.get('typeDependency').setValue(this.flagDep)
            this.dependenciaChanged(this.flagDep, 'EDIT')
          }
        }
        else{
          this.requestData.typeDependencies = []
          this.requestData.typeManagingEntitys = []
          this.formRequestIdentification.get('typeDependency').setValue(null)
          this.formRequestIdentification.get('typeManagingEntity').setValue(null)
        }
      }
    );
  }

  //entidad gestora
  dependenciaChanged(dependenciaId: number, flag: string) {
    this.regProMaestroService
      .getAllByCodGropAndIdMaestropadre('5',dependenciaId)
      .subscribe((data) => {
        let datos = data['data']
        if( datos.length > 0 ){
          this.requestData.typeManagingEntitys = datos
          if( flag === 'EDIT' ){
            this.formRequestIdentification.get('typeManagingEntity').setValue(this.flagEntGes)
          }
        }
        else{
          this.requestData.typeManagingEntitys = []
          this.formRequestIdentification.get('typeManagingEntity').setValue(null)
        }
      }
    );
  }

  searchSolicitud() {
    // 1654489
    if(this.formRequestIdentification.get('search').value === null){
      Swal.fire(
        '¡ Validación !',
        'Ingresa código modular',
        'warning'
      )
    }else{
      this.regProProgramaService
        .getProgramaByCodigoModular(this.formRequestIdentification.get('search').value, this.datosUser['codUgel'])
        .subscribe((data) => {
          let datos = data['data']
          console.log(datos)
          this.utilRegistroService.ProgramData(datos)
        }
      );
    }
  }

  onChangeCheck(isCheck, flag: string): void {
    if( flag === 'NAME' ){
      this.flagReadOnlyName = isCheck? false : true
    }
    else if( flag === 'GESTION' ){
      this.flagReadOnlyGestion = isCheck? false : true
    }
    else if( flag === 'PROGRAMA' ){
      this.flagReadOnlyPrograma = isCheck? false : true
    }
    else if( flag === 'DEPENDENCIA' ){
      this.flagReadOnlyDependencia = isCheck? false : true
    }
    else if( flag === 'GESTORA' ){
      this.flagReadOnlyGestora = isCheck? false : true
    }
  }

}
