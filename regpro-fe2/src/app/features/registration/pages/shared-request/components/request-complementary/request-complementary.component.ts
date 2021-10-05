import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormControl, Validators } from "@angular/forms";
import { take } from "rxjs/operators";
import { RequestDataModel } from "src/app/models/requestdata.model";
import { UtilRegistroService } from "src/app/services/util-registro.service";
import { RegProMaestroService } from "src/app/services/tbl-regpro-maestro/tbl-regpro-maestro.service";

@Component({
  selector: "rgp-request-complementary",
  templateUrl: "./request-complementary.component.html",
  styleUrls: ["./request-complementary.component.css"],
})
export class RequestComplementaryComponent implements OnInit {
  requestData: RequestDataModel;

  @Input() formRequestComplementary: FormGroup;
  @Input() flagReadOnlyControls: boolean;
  @Input() flagCheckEdit: boolean;

  selectedTypeShift: number = 0;
  selectedTypeContinuity: number = 0;
  selectedTypeWaterProvider: number = 0;
  selectedTypeEnergyProvider: number = 0;

  disableWaterSupply: boolean = false;
  disableEnergySupply: boolean = false;

  public flagReadOnlyTurno: boolean = true
  public flagReadOnlySerAgua: boolean = true
  public flagReadOnlySerEnergia: boolean = true

  constructor(
    private _fb: FormBuilder,
    private utilRegistroService: UtilRegistroService,
    private regProMaestroService: RegProMaestroService
  ) {
    this.requestData = new RequestDataModel()
  }

  ngOnInit() {
    this.loadData();
    this.utilRegistroService.changeProgramData.subscribe(isProgramData => {
      this.formRequestComplementary.get('selectedTypeShift').setValue(isProgramData.nIdTipturn)
      this.formRequestComplementary.get('selectedTypeContinuity').setValue(isProgramData.nIdTipcjes)
      this.formRequestComplementary.get('selectedTypeWaterProvider').setValue(isProgramData.nIdTipprag)
      this.formRequestComplementary.get('otherWaterProvider').setValue(isProgramData.cOtrpragua)
      this.formRequestComplementary.get('supplyWaterNumber').setValue(isProgramData.cSumagua)
      this.formRequestComplementary.get('selectedTypeEnergyProvider').setValue(isProgramData.nIdTippren)
      this.formRequestComplementary.get('otherEnergyProvider').setValue(isProgramData.cOtrprener)
      this.formRequestComplementary.get('supplyEnergyNumber').setValue(isProgramData.cSumener)
    });
  }

  loadData() {
    //turno
    this.regProMaestroService
      .getAllByCodGrop('8')
      .subscribe((data) => {
        let datos = data['data']
        this.requestData.typeShift = datos;
      }
    );
    //Continuidad
    this.regProMaestroService
      .getAllByCodGrop('9')
      .subscribe((data) => {
        let datos = data['data']
        this.requestData.typeContinuity = datos;
      }
    );
    //servicio de agua
    this.regProMaestroService
      .getAllByCodGrop('14')
      .subscribe((data) => {
        let datos = data['data']
        this.requestData.typeWaterProvider = datos;
      }
    );
    //servicio de energia
    this.regProMaestroService
      .getAllByCodGrop('13')
      .subscribe((data) => {
        let datos = data['data']
        this.requestData.typeEnergyProvider = datos;
      }
    );
  }

  turnoChanged(idTurno){
    if(idTurno === '75'){
      this.formRequestComplementary.get('selectedTypeContinuity').setValue(77)
      this.formRequestComplementary.get('selectedTypeContinuity').disable()
    }else{
      this.formRequestComplementary.get('selectedTypeContinuity').setValue(76)
      this.formRequestComplementary.get('selectedTypeContinuity').enable()
    }
  }

  waterProviderChanged(waterProviderId) {
    if(waterProviderId == 172) {
      this.disableWaterSupply = true;
    }
    else {
      this.disableWaterSupply = false;
    }
  }

  energyProviderChanged(energyProviderId) {
    if (energyProviderId == 120) {
      this.disableEnergySupply = true;
    }
    else {
      this.disableEnergySupply = false;
    }
  }

  onChangeCheck(isCheck, flag: string): void {
    if( flag === 'TURNO' ){
      this.flagReadOnlyTurno = isCheck? false : true
    }
    else if( flag === 'AGUA' ){
      this.flagReadOnlySerAgua = isCheck? false : true
    }
    else if( flag === 'ENERGIA' ){
      this.flagReadOnlySerEnergia = isCheck? false : true
    }
  }

}
