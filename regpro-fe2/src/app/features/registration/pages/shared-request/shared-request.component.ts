import { Component, OnInit, TemplateRef, ViewChild, Input } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { RequestMapComponent } from "src/app/components";
import { NgxSpinnerService } from "ngx-spinner";
import Swal from 'sweetalert2'
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { RequestModel } from 'src/app/models/request.model';
import { RequestFile } from 'src/app/models/requestfile.model';
import { Utilfunctions } from "src/app/services/util-functions.service";
import { UtilRegistroService } from "src/app/services/util-registro.service";
import { TblRegproSolicitudService } from "src/app/services/tbl-regpro-solicitud/tbl-regpro-solicitud.service";
import { TblregprosolicitudModel } from "../../../../models/tblregprosolicitud/tblregprosolicitud.model";
import { TblRegproDocumentoModel } from "../../../../models/tblregprosolicitud/tblRegprodocumento.model";
//import { MatDialogConfig } from '@angular/material/dialog';
//import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {MessageTurnosDialogComponent} from 'src/app/components/message-turnos/message-turnos.component';

@Component({
  selector: 'rgp-shared-request',
  templateUrl: './shared-request.component.html',
  styleUrls: ['./shared-request.component.css']
})
export class SharedRequestPage implements OnInit {

  solicitudFrom : FormGroup;
  @ViewChild("map")
  mapChartChildComponent: RequestMapComponent;
  files: File[];
  generateCode: string;

  modalRef: BsModalRef;
  idNewRequest: number = 0;
  disableSubmissionButtons: boolean = false;

  @ViewChild("savingRequestModal") savingModal: TemplateRef<any>;

  @Input() flagSearch: boolean;
  @Input() flagReadOnlyControls: boolean;
  @Input() titleMenu: string;
  @Input() title: string;
  @Input() flagCheckEdit: boolean;
  @Input() typeSend: number;

  public croquis: any = null
  public filesDocumentation : any[] = []
  public file1: any = null
  public file2: any = null
  public file3: any = null
  public file4: any = null
  public file5: any = null

  constructor(
    private fb:FormBuilder,
    private spinner: NgxSpinnerService,
    private utilRegistroService: UtilRegistroService,
    private tblRegproSolicitudService: TblRegproSolicitudService,
    private utilfunctions: Utilfunctions,
  ) { }

  onFilesUpdated(files: File[]) {
    this.files = files;
    console.log(this.files)
  }

  discardRequest() {}

  onNewGenerateCode(newCode: string) {
    this.generateCode = newCode;
  }

  ngOnInit() {
    this.createForm();
    this.utilRegistroService.changeCroquisData.subscribe(isCroquisData => {
      this.croquis = isCroquisData
    });
    this.utilRegistroService.changeFilesData.subscribe(isFilesData => {
      this.filesDocumentation = isFilesData
      for (let index = 0; index < this.filesDocumentation.length; index++) {
        if(index === 0){
          this.file1 = this.filesDocumentation[index]
        }else if(index === 1){
          this.file2 = this.filesDocumentation[index]
        }else if(index === 2){
          this.file3 = this.filesDocumentation[index]
        }else if(index === 3){
          this.file4 = this.filesDocumentation[index]
        }else if(index === 4){
          this.file5 = this.filesDocumentation[index]
        }
      }
    });
  }

  createForm(){
    this.solicitudFrom = this.fb.group({
      formRequestIdentification : this.fb.group({
        search: new FormControl({ value: '', disabled: false }),
        name: new FormControl({ value: '', disabled: false }, [Validators.required, Validators.maxLength(50)]),
        typeManagement: new FormControl({ value: 26, disabled: false }, [Validators.required]),
        typeProgram: new FormControl({ value: 1, disabled: false }, [Validators.required]),
        typeDependency: new FormControl({ value: '', disabled: false }, [Validators.required]),
        typeManagingEntity: new FormControl({ value: '', disabled: false }, [Validators.required])
      }),
      formRequestLocation : this.fb.group({
        selectedRegion: new FormControl({ value: '', disabled: false }, [Validators.required]),
        selectedProvince: new FormControl({ value: '', disabled: false }, Validators.required),
        selectedDistrict: new FormControl({ value: '', disabled: false }, Validators.required),
        selectedVillageCode: new FormControl({ value: '', disabled: false }, Validators.required),
        selectedVillageName: new FormControl({ value: '', disabled: false }, Validators.required),
        selectedVillageLongitudeHidden: new FormControl({ value: '', disabled: false }, Validators.required),
        selectedVillageLatitudeHidden: new FormControl({ value: '', disabled: false }, Validators.required),
        selectedVillageAreaHidden: new FormControl({ value: '', disabled: false }, Validators.required),
        selectedVillageAreaSigHidden: new FormControl({ value: '', disabled: false }, Validators.required),
        selectedVillageLongitude: new FormControl({ value: '', disabled: false }, Validators.required),
        selectedVillageLatitude: new FormControl({ value: '', disabled: false }, Validators.required),
        selectedVillageGeoLocalization: new FormControl({ value: '', disabled: false }),
        typeAvenueSelected: new FormControl({ value: 16, disabled: false }, Validators.required),
        nameOfRoad: new FormControl({ value: '', disabled: false }, Validators.required),
        numberAddress: new FormControl({ value: '', disabled: false }, Validators.required),
        blockAddress: new FormControl({ value: '', disabled: false }, Validators.required),
        lotAddress: new FormControl({ value: '', disabled: false }, Validators.required),
        typeLocationSelected: new FormControl({ value: 48, disabled: false }, Validators.required),
        location: new FormControl({ value: '', disabled: false }, Validators.required),
        stage: new FormControl({ value: '', disabled: false }, Validators.required),
        sector: new FormControl({ value: '', disabled: false }, Validators.required),
        zone: new FormControl({ value: '', disabled: false }, Validators.required),
        reference: new FormControl({ value: '', disabled: false }, Validators.required),
        codeNeareastEducationCentre: new FormControl({ value: '', disabled: false }, [Validators.maxLength(7), Validators.minLength(7)]),
        numberNameNearestEducationCentre: new FormControl({ value: '', disabled: false }),
        nearestEducationCentreSemclat: new FormControl({ value: '', disabled: false }),
        nearestEducationCentreSemclon: new FormControl({ value: '', disabled: false })
      }),
      formRequestSupportDocumentation : this.fb.group({
        selectedTypeDocument: new FormControl({ value: 60, disabled: false }, [Validators.required]),
        resolutionNumber: new FormControl({ value: '', disabled: false }, [Validators.required]),
        resolutionDate: new FormControl({ value: new Date(), disabled: false }, [Validators.required]),
        codeGenerate: new FormControl({ value: '', disabled: false }, [Validators.required])
      }),
      formRequestComplementary : this.fb.group({
        selectedTypeShift: new FormControl({ value: 72, disabled: false }),
        selectedTypeContinuity: new FormControl({ value: 76, disabled: false }),
        selectedTypeWaterProvider: new FormControl({ value: 121, disabled: false }),
        otherWaterProvider: new FormControl({ value: '', disabled: false }),
        supplyWaterNumber: new FormControl({ value: '', disabled: false }),
        selectedTypeEnergyProvider: new FormControl({ value: 93, disabled: false }),
        otherEnergyProvider: new FormControl({ value: '', disabled: false }),
        supplyEnergyNumber: new FormControl({ value: '', disabled: false }),
      })
    })
  }

  onVillageSelected(coordinates: any) {
    if (coordinates) {
      console.log(
        `Coordinates in the page, longitude: ${coordinates.longitude}, latitude: ${coordinates.latitude}`
      );
      this.mapChartChildComponent.changeLatitudeLongitude(
        coordinates.latitude,
        coordinates.longitude,
        coordinates.zoom ?? 15.5
      );
    } else {
      this.mapChartChildComponent.resetPosition();
    }
  }

  onSubmit(){
    if(this.solicitudFrom.valid){
      Swal.fire({
        title: '¿ Deseas guardar ?',
        text: '¡ Verifica tus datos antes de guardar !',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: '¡ Sí !',
        cancelButtonText: 'No'
      }).then((result) => {
        if (result.isConfirmed) {
          this.saveData()
        } else if (result.dismiss === Swal.DismissReason.cancel) {
          Swal.fire(
            '¡ Cancelado !',
            'Tu información está segura',
            'warning'
          )
        }
      })
    }else{
      Swal.fire(
        '¡ Validación !',
        'Verifica tus datos ingresados',
        'warning'
      )
    }
  }

  saveData(){
    this.spinner.show();
    const currentUser = JSON.parse(localStorage.getItem('datosUser'));

    let documento: TblRegproDocumentoModel =<TblRegproDocumentoModel>{
      nIdTipreso: this.solicitudFrom.value.formRequestSupportDocumentation.selectedTypeDocument,
      cNrodoc: this.solicitudFrom.value.formRequestSupportDocumentation.resolutionNumber,
      dFecdocu: this.solicitudFrom.value.formRequestSupportDocumentation.resolutionDate,
      cCoddocu: this.solicitudFrom.value.formRequestSupportDocumentation.codeGenerate,
      cUsucre: currentUser.userName,
      codooii: currentUser.codUgel,
      nIdTipdocu: null,
      dFeccre: null,
      dFecumo: null,
      cUsuumo: null,
      cEstado: null
    }

    let request: TblregprosolicitudModel = <TblregprosolicitudModel>{
     nIdTipsoli: this.typeSend,
     codigo: currentUser.codUgel,
     cCodmod: this.typeSend === 268 ? '' : this.solicitudFrom.value.formRequestIdentification.search,
     //IDENTIFICACIÓN
     cNomprog: this.solicitudFrom.value.formRequestIdentification.name,
     nIdTipprog: parseInt(this.solicitudFrom.value.formRequestIdentification.typeProgram),
     nIdTipgest: parseInt(this.solicitudFrom.value.formRequestIdentification.typeManagement),
     nIdTipdepe: parseInt(this.solicitudFrom.value.formRequestIdentification.typeDependency),
     nIdTipeges: parseInt(this.solicitudFrom.value.formRequestIdentification.typeManagingEntity),
     //UBICACIÓN
     idDistrito: this.solicitudFrom.value.formRequestLocation.selectedDistrict,
     cCodccpp: this.solicitudFrom.value.formRequestLocation.selectedVillageCode,
     cNomccpp: this.solicitudFrom.value.formRequestLocation.selectedVillageName,
     nProlat: this.solicitudFrom.value.formRequestLocation.selectedVillageLatitude,
     nProlon: this.solicitudFrom.value.formRequestLocation.selectedVillageLongitude,
     nIdTipvia: parseInt(this.solicitudFrom.value.formRequestLocation.typeAvenueSelected),
     cDirnomvia: this.solicitudFrom.value.formRequestLocation.nameOfRoad,
     cDirnumvia: this.solicitudFrom.value.formRequestLocation.numberAddress,
     cDirmz: this.solicitudFrom.value.formRequestLocation.blockAddress,
     cDirlote: this.solicitudFrom.value.formRequestLocation.lotAddress,
     nIdTiplocd: parseInt(this.solicitudFrom.value.formRequestLocation.typeLocationSelected),
     cDirlocd: this.solicitudFrom.value.formRequestLocation.location,
     cDiretap: this.solicitudFrom.value.formRequestLocation.stage,
     cDirsect: this.solicitudFrom.value.formRequestLocation.sector,
     cDirzona: this.solicitudFrom.value.formRequestLocation.zone,
     cDirrefe: this.solicitudFrom.value.formRequestLocation.reference,
     cCsemc: this.solicitudFrom.value.formRequestLocation.codeNeareastEducationCentre,
     cNomsemc: this.solicitudFrom.value.formRequestLocation.numberNameNearestEducationCentre,
     //UBICACIÓN HIDDEN
     nCcpplat: this.solicitudFrom.value.formRequestLocation.selectedVillageLatitudeHidden,
     nCcpplon: this.solicitudFrom.value.formRequestLocation.selectedVillageLongitudeHidden,
     cCodArea: this.solicitudFrom.value.formRequestLocation.selectedVillageAreaHidden,
     cCodAreasig: this.solicitudFrom.value.formRequestLocation.selectedVillageAreaSigHidden,
     nSemclat: this.solicitudFrom.value.formRequestLocation.nearestEducationCentreSemclat,
     nSemclon: this.solicitudFrom.value.formRequestLocation.nearestEducationCentreSemclon,
     //SUSTENTATORIA
     documento: documento,
     //COMPLEMENTARIOS
     nIdTipturn: parseInt(this.solicitudFrom.value.formRequestComplementary.selectedTypeShift),
     nIdTipcjes: parseInt(this.solicitudFrom.value.formRequestComplementary.selectedTypeContinuity),
     nIdTipprag: parseInt(this.solicitudFrom.value.formRequestComplementary.selectedTypeWaterProvider),
     cOtrpragua: this.solicitudFrom.value.formRequestComplementary.otherWaterProvider,
     cSumagua: this.solicitudFrom.value.formRequestComplementary.supplyWaterNumber,
     nIdTippren: parseInt(this.solicitudFrom.value.formRequestComplementary.selectedTypeEnergyProvider),
     cOtrprener: this.solicitudFrom.value.formRequestComplementary.otherEnergyProvider,
     cSumener: this.solicitudFrom.value.formRequestComplementary.supplyEnergyNumber,
     //NULLS
     nIdTipsitu: 0,
     cCodsoli: null,
     cDirotro: null,
     dFecenv: null,
     cUsumodi: null,
     cNomusumodi: null,
     dFecmodi: null,
     cUsurevi: null,
     cNomusurevi: null,
     dFecrevi: null,
     cUsurevs: null,
     cNomusurevs: null,
     dFecrevs: null,
     dFecaten: null,
     dFecumo: null,
     cUsuumo: null,
     cGeohash: null,
     nIdTipsituprog: 0,
     nIdTipsiturev: 0,
     nIdTipsiturevsig: 0,
     nIdTipoperiodo: 0,
     cIndult: null,
     cEstado: '1',
     //DATOS
     cUsuenv: currentUser.userName,
     cNomusuenv: currentUser.name + " " + currentUser.lastName,
     cUsucre: currentUser.userName
    }

    console.log(this.croquis)
    console.log(this.file1)
    console.log(this.file2)
    console.log(this.file3)
    console.log(this.file4)
    console.log(this.file5)
    const formData = new FormData()
    formData.append("NIdTipsoli", String(this.typeSend));
    formData.append("Codigo", currentUser.codUgel);
    formData.append("CCodmod", this.typeSend === 268 ? '' : this.solicitudFrom.value.formRequestIdentification.search);
    //IDENTIFICACIÓN
    formData.append("CNomprog", this.solicitudFrom.value.formRequestIdentification.name);
    formData.append("NIdTipprog", this.solicitudFrom.value.formRequestIdentification.typeProgram);
    formData.append("NIdTipgest", this.solicitudFrom.value.formRequestIdentification.typeManagement);
    formData.append("NIdTipdepe", this.solicitudFrom.value.formRequestIdentification.typeDependency);
    formData.append("NIdTipeges", this.solicitudFrom.value.formRequestIdentification.typeManagingEntity);
    //UBICACIÓN
    formData.append("IdDistrito", this.solicitudFrom.value.formRequestLocation.selectedDistrict);
    formData.append("CCodccpp", this.solicitudFrom.value.formRequestLocation.selectedVillageCode);
    formData.append("CNomccpp", this.solicitudFrom.value.formRequestLocation.selectedVillageName);
    // formData.append("nProlat", this.solicitudFrom.value.formRequestLocation.selectedVillageLatitude);
    // formData.append("nProlon", this.solicitudFrom.value.formRequestLocation.selectedVillageLongitude);
    formData.append("NProlat", this.solicitudFrom.value.formRequestLocation.selectedVillageLatitudeHidden);
    formData.append("NProlon", this.solicitudFrom.value.formRequestLocation.selectedVillageLongitudeHidden);
    formData.append("NIdTipvia", this.solicitudFrom.value.formRequestLocation.typeAvenueSelected);
    formData.append("CDirnomvia", this.solicitudFrom.value.formRequestLocation.nameOfRoad);
    formData.append("CDirnumvia", this.solicitudFrom.value.formRequestLocation.numberAddress);
    formData.append("CDirmz", this.solicitudFrom.value.formRequestLocation.blockAddress);
    formData.append("CDirlote", this.solicitudFrom.value.formRequestLocation.lotAddress);
    formData.append("NIdTiplocd", this.solicitudFrom.value.formRequestLocation.typeLocationSelected);
    formData.append("CDirlocd", this.solicitudFrom.value.formRequestLocation.location);
    formData.append("CDiretap", this.solicitudFrom.value.formRequestLocation.stage);
    formData.append("CDirsect", this.solicitudFrom.value.formRequestLocation.sector);
    formData.append("CDirzona", this.solicitudFrom.value.formRequestLocation.zone);
    formData.append("CDirrefe", this.solicitudFrom.value.formRequestLocation.reference);
    formData.append("CCsemc", this.solicitudFrom.value.formRequestLocation.codeNeareastEducationCentre);
    formData.append("CNomsemc", this.solicitudFrom.value.formRequestLocation.numberNameNearestEducationCentre);
    //UBICACIÓN HIDDEN
    formData.append("NCcpplat", this.solicitudFrom.value.formRequestLocation.selectedVillageLatitudeHidden);
    formData.append("NCcpplon", this.solicitudFrom.value.formRequestLocation.selectedVillageLongitudeHidden);
    formData.append("CCodArea", this.solicitudFrom.value.formRequestLocation.selectedVillageAreaHidden);
    formData.append("CCodAreasig", this.solicitudFrom.value.formRequestLocation.selectedVillageAreaSigHidden);
    formData.append("NSemclat", this.solicitudFrom.value.formRequestLocation.nearestEducationCentreSemclat);
    formData.append("NSemclon", this.solicitudFrom.value.formRequestLocation.nearestEducationCentreSemclon);
    //SUSTENTATORIA
    formData.append("Documento.NIdTipreso", this.solicitudFrom.value.formRequestSupportDocumentation.selectedTypeDocument);
    formData.append("Documento.CNrodoc", this.solicitudFrom.value.formRequestSupportDocumentation.resolutionNumber);
    formData.append("Documento.DFecdocu", this.solicitudFrom.value.formRequestSupportDocumentation.resolutionDate);
    formData.append("Documento.CCoddocu", this.solicitudFrom.value.formRequestSupportDocumentation.codeGenerate);
    formData.append("Documento.CUsucre", currentUser.userName);
    formData.append("Documento.Codooii", currentUser.codUgel);
    formData.append("Documento.NIdTipdocu", '0');
    formData.append("Documento.DFeccre", this.utilfunctions.returnFecha());
    formData.append("Documento.DFecumo", '');
    formData.append("Documento.CUsuumo", '');
    formData.append("Documento.CEstado", '');
    //COMPLEMENTARIOS
    formData.append("NIdTipturn", this.solicitudFrom.value.formRequestComplementary.selectedTypeShift);
    formData.append("NIdTipcjes", this.solicitudFrom.value.formRequestComplementary.selectedTypeContinuity);
    formData.append("NIdTipprag", this.solicitudFrom.value.formRequestComplementary.selectedTypeWaterProvider);
    formData.append("COtrpragua", this.solicitudFrom.value.formRequestComplementary.otherWaterProvider);
    formData.append("CSumagua", this.solicitudFrom.value.formRequestComplementary.supplyWaterNumber);
    formData.append("NIdTippren", this.solicitudFrom.value.formRequestComplementary.selectedTypeEnergyProvider);
    formData.append("COtrprener", this.solicitudFrom.value.formRequestComplementary.otherEnergyProvider);
    formData.append("CSumener", this.solicitudFrom.value.formRequestComplementary.supplyEnergyNumber);
    //NULLS
    formData.append("NIdTipsitu", '0');
    formData.append("CCodsoli", '');
    formData.append("CDirotro", '');
    formData.append("DFecenv", '');
    formData.append("CUsumodi", '');
    formData.append("CNomusumodi", '');
    formData.append("DFecmodi", '');
    formData.append("CUsurevi", '');
    formData.append("CNomusurevi", '');
    formData.append("DFecrevi", '');
    formData.append("CUsurevs", '');
    formData.append("CNomusurevs", '');
    formData.append("DFecrevs", '');
    formData.append("DFecaten", '');
    formData.append("DFecumo", '');
    formData.append("CUsuumo", '');
    formData.append("CGeohash", '');
    formData.append("NIdTipsituprog", '0');
    formData.append("NIdTipsiturev", '0');
    formData.append("NIdTipsiturevsig", '0');
    formData.append("NIdTipoperiodo",' 0');
    formData.append("CIndult", '');
    formData.append("CEstado", '1');
    //DATOS
    formData.append("CUsuenv", currentUser.userName);
    formData.append("CNomusuenv", currentUser.name + " " + currentUser.lastName);
    formData.append("CUsucre", currentUser.userName);
    //FILES PDF
    formData.append("croquis", this.croquis);
    formData.append("file1", this.file1);
    formData.append("file2", this.file2);
    formData.append("file3", this.file3);
    formData.append("file4", this.file4);
    formData.append("file5", this.file5);

    // console.log(formData)
    formData.forEach((value,key) => {
      console.log(key + " : " + value)
    });

    this.tblRegproSolicitudService
    .saveRequest(formData)
    .subscribe((data) => {
      this.spinner.hide();
      if(data){
        console.log(data);
        Swal.fire(
          '¡ Confirmación !',
          'Los datos se guardaron correctamente',
          'success'
        )
        this.solicitudFrom.reset();
      }else{
        Swal.fire(
          '¡ Confirmación !',
          'Ocurrio un error',
          'error'
        )
      }
    }, error => {
      this.spinner.hide();
      Swal.fire(
        '¡ Confirmación !',
        'Ocurrio un error',
        'error'
      )
    });
  }

  closeSavingModal() {
    this.modalRef.hide();
  }

  confirmCreation() {
    this.modalRef.hide();
  }
  openDialogMesagge(title, message) {
    /*const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      "isCancel" : false,
      "isConfirm" : true,
      "title" : title,
      "message" : message,
      "state" : "warning"
    }
    const dialogRef2 = this.dialog.open(MessageTurnosDialogComponent, dialogConfig);  */
  }

}
