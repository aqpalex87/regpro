import { Component, OnInit, Output, TemplateRef, EventEmitter, Input, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from "@angular/forms";
import Swal from 'sweetalert2'
//import { ConfigService } from './configuration-table.service';
import { Utilfunctions } from "src/app/services/util-functions.service";
import { UbigeoModel } from 'src/app/models/ubigeo.model';
import { ProvinceModel } from 'src/app/models/province.model';
import { DistrictModel } from 'src/app/models/district.model';
import { VillageCentre } from 'src/app/models/villagecentre.model';
import { RequestDataModel } from 'src/app/models/requestdata.model';
import { RegProMaestroService } from "src/app/services/tbl-regpro-maestro/tbl-regpro-maestro.service";
import { RegProProgramaService } from "src/app/services/tbl-regpro-programa/tbl-regpro-programa.service";
import { RegionService } from "src/app/services/region/region.service";
import { ProvinciaService } from "src/app/services/provincia/provincia.service";
import { DistritoService } from "src/app/services/distrito/distrito.service";
import { take } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { VillagecentreService } from 'src/app/services/villagecentre.service';
import { UtilRegistroService } from "src/app/services/util-registro.service";

import { Columns, Config, DefaultConfig } from 'ngx-easy-table';

@Component({
  selector: 'rgp-request-location',
  templateUrl: './request-location.component.html',
  styleUrls: ['./request-location.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RequestLocationComponent implements OnInit {
  requestData: RequestDataModel;
  ubigeoData: UbigeoModel;
  provinces: ProvinceModel[];
  districts: DistrictModel[];

  public typeLocationSelected: number = 0;

  public disableVillageCentre: boolean = true;
  public villages: any[] = [];
  public page=4;
  public pageSize = 10;

  public selectedVillage: VillageCentre;

  public fileToUpload: File | null = null;

  @Output() onVillageSeleted: EventEmitter<any> = new EventEmitter<any>();

  @Input() formRequestLocation: FormGroup;
  @Input() flagReadOnlyControls: boolean;
  @Input() flagCheckEdit: boolean;

  public datosUser: any

  public flagReadOnlyUbigeo: boolean = true
  public flagReadOnlyCenPoblado: boolean = true
  public flagReadOnlyCoordenadas: boolean = true
  public flagReadOnlyDireccion: boolean = true
  public flagReadOnlyReferencia: boolean = true
  public flagReadOnlyServEducativo: boolean = true

  modalRef: BsModalRef;

  public tamanioFile : number = 3 * 1024 * 1024;

  public flagRegi: string = null
  public flagProv: string = null
  public flagDist: string = null

  public datosCentroPoblado: any = {}

  //table
  public columns: Columns[] = [
    { key: 'codcp', title: 'Código CP' },
    { key: 'nomB_UBIGEO', title: 'Nombre CP' },
    { key: 'ubigeo', title: 'Ubigeo' }
  ];
  public configuration: Config;

  constructor(
    private _fb: FormBuilder,
    private utilfunctions: Utilfunctions,
    private utilRegistroService: UtilRegistroService,
    private modalService: BsModalService,
    private regProMaestroService: RegProMaestroService,
    private regProProgramaService: RegProProgramaService,
    private regionService: RegionService,
    private provinciaService: ProvinciaService,
    private distritoService: DistritoService,
    private villageService: VillagecentreService
  ) {
    this.ubigeoData = new UbigeoModel()
    this.requestData = new RequestDataModel()
    this.configuration = { ...DefaultConfig };
    this.configuration.searchEnabled = true;
    this.configuration.selectRow = true;
  }

  ngOnInit() {
    this.datosUser = JSON.parse(localStorage.getItem('datosUser'))
    this.loadRegion('VIEW');
    this.loadData();
    this.utilRegistroService.changeProgramData.subscribe(isProgramData => {
      this.flagRegi = (isProgramData.codooii).substr(0,2)
      this.flagProv = (isProgramData.codooii).substr(0,4)
      this.flagDist = (isProgramData.codooii).substr(0,6)
      // this.formRequestLocation.get('selectedRegion').setValue()
      // this.formRequestLocation.get('selectedProvince').setValue()
      // this.formRequestLocation.get('selectedDistrict').setValue()
      this.formRequestLocation.get('selectedVillageCode').setValue(isProgramData.cCodccpp)
      this.formRequestLocation.get('selectedVillageName').setValue(isProgramData.cNomccpp)
      this.formRequestLocation.get('selectedVillageLatitude').setValue(isProgramData.nProlat)
      this.formRequestLocation.get('selectedVillageLongitude').setValue(isProgramData.nProlon)
      this.formRequestLocation.get('typeAvenueSelected').setValue(isProgramData.nIdTipvia)
      this.formRequestLocation.get('nameOfRoad').setValue(isProgramData.cDirnomvia)
      this.formRequestLocation.get('numberAddress').setValue(isProgramData.cDirnumvia)
      this.formRequestLocation.get('blockAddress').setValue(isProgramData.cDirmz)
      this.formRequestLocation.get('lotAddress').setValue(isProgramData.cDirlote)
      this.formRequestLocation.get('typeLocationSelected').setValue(isProgramData.nIdTiplocd)
      this.formRequestLocation.get('location').setValue(isProgramData.cDirlocd)
      this.formRequestLocation.get('stage').setValue(isProgramData.cDiretap)
      this.formRequestLocation.get('sector').setValue(isProgramData.cDirsect)
      this.formRequestLocation.get('zone').setValue(isProgramData.cDirzona)
      this.formRequestLocation.get('reference').setValue(isProgramData.cDirrefe)
      this.formRequestLocation.get('codeNeareastEducationCentre').setValue(isProgramData.cCsemc)
      this.formRequestLocation.get('numberNameNearestEducationCentre').setValue(isProgramData.cNomsemc)
      this.onVillageSeleted.emit({
        longitude: isProgramData.nProlon,
        latitude: isProgramData.nProlat,
        zoom: isProgramData.nzoom
      });
    });
  }

  loadRegion(flag: string): void {
    //carga combo ubigeo '150102'
    this.regionService
      .getRegionData(this.datosUser['codUgel'])
      .subscribe((data) => {
        let datos = data['data']
        this.ubigeoData.regions = datos;
        if( flag === 'EDIT' ){

        }
      }
    );
  }

  loadData(): void {
    //carga combo avenidas
    this.regProMaestroService
      .getAllByCodGrop('2')
      .subscribe((data) => {
        let datos = data['data']
        this.requestData.typeAvenues = datos
      }
    );
    //carga combo localidad
    this.regProMaestroService
      .getAllByCodGrop('6')
      .subscribe((data) => {
        let datos = data['data']
        this.requestData.typeLocation = datos
      }
    );
  }

  departamentChanged(departmentId) {
    this.provinciaService
      .getProvinciaByIdRegionData(this.datosUser['codUgel'], departmentId)
      .subscribe((data) => {
        let datos = data['data']
        this.ubigeoData.provinces = datos
      })
    // this.provinces = this.ubigeoData.provinces.filter((p) =>{
    //   return p.region_Id == departmentId;
    // });
    // this.formRequestLocation.patchValue({
    //   selectedProvince: '',
    //   selectedDistrict: ''
    // });
    this.disableVillageCentre = true;
    let selectedDepartament = this.ubigeoData.regions.filter((d) => d.idRegion == departmentId);
    this.onVillageSeleted.emit({
      longitude: selectedDepartament[0].pointX,
      latitude: selectedDepartament[0].pointY,
      zoom: selectedDepartament[0].zoom
    });
  }

  provinceChanged(provinceId) {
    this.distritoService
      .getDistritoByIdProvinciaData(this.datosUser['codUgel'], provinceId)
      .subscribe((data) => {
        let datos = data['data']
        this.ubigeoData.districts = datos
      })
    // this.districts = this.ubigeoData.districts.filter((d) => {
    //   return d.provinceId == provinceId;
    // });
    // this.formRequestLocation.patchValue({
    //   selectedDistrict: ''
    // });
    // // this.selectedDistrict = "";
    this.disableVillageCentre = true;
    let selectedProvince = this.ubigeoData.provinces.filter((d) => d.idProvincia == provinceId);
    this.onVillageSeleted.emit({
      longitude: selectedProvince[0].pointX,
      latitude: selectedProvince[0].pointY,
      zoom: selectedProvince[0].zoom
    });
  }

  districtChanged(districtId) {
    if (districtId != 0) {
      this.disableVillageCentre = false;
      this.villageService
      .getVillageCentre(districtId,this.datosUser['codUgel'])
      .subscribe((villages) => {
        console.log(villages)
        this.villages = villages.map((v) => ({
          ubigeo: v.ubigeo,
          codcp: v.codcp,
          denominacion: v.denominacion,
          longituD_DEC: v.longituD_DEC,
          latituD_DEC: v.latituD_DEC,
          area: v.area,
          areA_SIG: v.areA_SIG,
          nomB_UBIGEO: v.nomB_UBIGEO,
          CUSTOMTEXT: `${v.denominacion} - (${v.nomB_UBIGEO})`
        }));
      });

      let selectedDistrict = this.ubigeoData.districts.filter((d) => d.idDistrito == districtId);
      this.onVillageSeleted.emit({
        longitude: selectedDistrict[0].pointX,
        latitude: selectedDistrict[0].pointY,
        zoom: selectedDistrict[0].zoom
      });
    }
    else
      this.disableVillageCentre = true;
  }

  openSearchVillagesModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
    this.datosCentroPoblado = {}
  }

  discarSelectedVillageCenter() {
     this.selectedVillage = null;
     this.formRequestLocation.patchValue({
       selectedVillageCode: null,
       selectedVillageName: null,
       selectedVillageLongitude: null,
       selectedVillageLatitude: null,
       selectedVillageGeoLocalization: null
     });
     this.onVillageSeleted.emit(null);
  }

  eventEmittedCentroPoblado($event: { event: string; value: any }): void {
    this.datosCentroPoblado = $event['value']['row']
    console.log(this.datosCentroPoblado)
  }

  confirmVillageSelection() {
     // let tempSelectedVillage = this.villages.filter((v) => v.CODCP == this.selectedVillage);
     // if (tempSelectedVillage.length > 0) {
     //   this.onVillageSeleted.emit({
     //     longitude: tempSelectedVillage[0].LONGITUD_DEC,
     //     latitude: tempSelectedVillage[0].LATITUD_DEC
     //   });
     //   this.selectedVillage = tempSelectedVillage[0];
     //   console.log("this.selectedVillage?.DENOMINACION", this.selectedVillage?.denominacion);
     //   console.log("this.selectedVillage", this.selectedVillage);
     //   this.formRequestLocation.patchValue({
     //     selectedVillageCode: this.selectedVillage?.codcp,
     //     selectedVillageName: this.selectedVillage.denominacion,
     //     selectedVillageLongitude: this.selectedVillage?.longituD_DEC,
     //     selectedVillageLatitude: this.selectedVillage.latituD_DEC,
     //     selectedVillageGeoLocalization: this.selectedVillage.ubigeo
     //   });
     // }
     if( !this.utilfunctions.isEmptyObject(this.datosCentroPoblado) ){
       this.formRequestLocation.patchValue({
         selectedVillageCode: this.datosCentroPoblado?.codcp,
         selectedVillageName: this.datosCentroPoblado.denominacion,
         selectedVillageLongitudeHidden: this.datosCentroPoblado?.longituD_DEC,
         selectedVillageLatitudeHidden: this.datosCentroPoblado.latituD_DEC,
         selectedVillageAreaHidden: this.datosCentroPoblado.area,
         selectedVillageAreaSigHidden: this.datosCentroPoblado.areA_SIG,

         selectedVillageLatitude: this.datosCentroPoblado.latituD_DEC,//
         selectedVillageLongitude: this.datosCentroPoblado?.longituD_DEC//
       });
       this.modalRef.hide();
     }else{
       alert('Seleccione Centro Poblado')
     }
  }

  cancelVillageSelection() {
     this.modalRef.hide();
  }

  uploadImage(file: any){
    this.utilRegistroService.CroquisData(file[0])
  }
  uploadFile(files: FileList) {
    this.fileToUpload = files.item(0);
  }

  searchServEducCerc() {
    let valor = this.formRequestLocation.get('codeNeareastEducationCentre').value
    if(valor!==null && String(valor).length>=7){
      const currentUser = JSON.parse(localStorage.getItem('datosUser'));
      //carga servicio educativo cercano
      this.regProProgramaService
        .getCenterEducationalNear(String(valor), currentUser.codUgel)
        .subscribe((data) => {
          if( !this.utilfunctions.isEmptyObject(data) ){
            let datos = data['data']
            this.formRequestLocation.get('codeNeareastEducationCentre').setValue(datos['cCodmod'])
            this.formRequestLocation.get('numberNameNearestEducationCentre').setValue(datos['cNomprog'])
            this.formRequestLocation.get('nearestEducationCentreSemclat').setValue(datos['nSemclat'])
            this.formRequestLocation.get('nearestEducationCentreSemclon').setValue(datos['nSemclon'])
            this.formRequestLocation.get('codeNeareastEducationCentre').disable()
          }else{
            this.setearEmptyServEduCerc('Sin resultados en tu búsqueda', true)
          }
        }
      );
    }else{
      this.setearEmptyServEduCerc('Código de servicio Educativo', true)
    }
  }

  setearEmptyServEduCerc(msg: string, flagMsg: boolean){
    this.formRequestLocation.get('codeNeareastEducationCentre').setValue('')
    this.formRequestLocation.get('numberNameNearestEducationCentre').setValue('')
    this.formRequestLocation.get('nearestEducationCentreSemclat').setValue('')
    this.formRequestLocation.get('nearestEducationCentreSemclon').setValue('')
    this.formRequestLocation.get('codeNeareastEducationCentre').enable()
    if(flagMsg){
      Swal.fire(
        '¡ Inválidado !',
        msg,
        'warning'
      )
    }
  }

  onChangeCheck(isCheck, flag: string): void {
    if( flag === 'UBIGEO' ){
      this.flagReadOnlyUbigeo = isCheck? false : true
    }
    else if( flag === 'CENPOBLADO' ){
      this.flagReadOnlyCenPoblado = isCheck? false : true
    }
    else if( flag === 'COORDENADAS' ){
      this.flagReadOnlyCoordenadas = isCheck? false : true
    }
    else if( flag === 'DIRECCION' ){
      this.flagReadOnlyDireccion = isCheck? false : true
    }
    else if( flag === 'REFERENCIA' ){
      this.flagReadOnlyReferencia = isCheck? false : true
    }
    else if( flag === 'SEREDUCATIVO' ){
      this.flagReadOnlyServEducativo = isCheck? false : true
    }
  }

}
