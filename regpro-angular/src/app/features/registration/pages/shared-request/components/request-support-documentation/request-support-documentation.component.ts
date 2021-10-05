import { Component, ElementRef, Input, OnInit, Output, ViewChild, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from "@angular/forms";
import { RequestDataModel } from 'src/app/models/requestdata.model';
import { DatePipe } from '@angular/common';
import { UtilRegistroService } from "src/app/services/util-registro.service";
// import { RegistrationService } from 'src/app/services/registration.service';
import { take } from 'rxjs/operators';
import { RegProMaestroService } from "src/app/services/tbl-regpro-maestro/tbl-regpro-maestro.service";

@Component({
  selector: 'rgp-request-support-documentation',
  templateUrl: './request-support-documentation.component.html',
  styleUrls: ['./request-support-documentation.component.css']
})
export class RequestSupportDocumentationComponent implements OnInit {

  @Input() formRequestSupportDocumentation: FormGroup;

  datepipe: DatePipe = new DatePipe('en-US');
  generateCode: string = "";

  @Output()
  onGeneratedCodeUpdated: EventEmitter<string> = new EventEmitter<string>();

  requestData: RequestDataModel;
  selectedTypeDocument: number = 0;
  resolutionNumber: string;
  resolutionDate: Date;

  addFilesFunctionDisabled: boolean = true;

  tempFilesToUpload: File | null = null;
  filesToUpload: File[] | null = null;

  public tamanioFile : number = 3 * 1024 * 1024;

  @Output()
  onFilesUpdated: EventEmitter<File[]> = new EventEmitter<File[]>();

  public filesDocumentation: any[] = []

  // @ViewChild("fileToUpload")
  // fileToUploadControl: ElementRef

  constructor(
    private _fb: FormBuilder,
    private regProMaestroService: RegProMaestroService,
    private utilRegistroService: UtilRegistroService,
  ) {
    this.requestData = new RequestDataModel()
  }

  ngOnInit() {
    this.loadData();
    this.tempFilesToUpload;
    this.filesToUpload = [];
    const d = new Date();
    d.setFullYear(d.getFullYear());
    const mes = (d.getMonth() < 10) ? ('0' + (d.getMonth() + 1)) : d.getMonth();
    const dia = (d.getDate() < 10) ? ('0' + d.getDate()) : d.getDate();
    let fechaActual = d.getFullYear() + '-' + mes + '-' + dia;
    this.formRequestSupportDocumentation.get("resolutionDate").setValue(fechaActual)
  }

  loadData() {
    this.regProMaestroService
      .getAllByCodGrop('7')
      .subscribe((data) => {
        let datos = data['data']
        console.log(datos)
        this.requestData.typeDocuments = datos
      }
    );
  }

  updateGenerateCode(newValue) {
    let generatedCode: string = "";
    this.selectedTypeDocument = this.formRequestSupportDocumentation.get("selectedTypeDocument").value;
    this.resolutionNumber = this.formRequestSupportDocumentation.get("resolutionNumber").value;
    this.resolutionDate = this.formRequestSupportDocumentation.get("resolutionDate").value;
    if (this.selectedTypeDocument != 0 && this.resolutionNumber && this.resolutionDate)
      generatedCode = `${this.selectedTypeDocument}-${this.resolutionNumber}-${this.datepipe.transform(this.resolutionDate, 'dd_MM_yyyy')}`;
    this.generateCode = generatedCode;
    this.formRequestSupportDocumentation.get('codeGenerate').setValue(this.generateCode)
    this.onGeneratedCodeUpdated.emit(this.generateCode);
  }

  uploadFile(files: any) { //files: FileList
    // this.tempFilesToUpload = files.item(0);
    console.log(files)
    this.tempFilesToUpload = files[0];
    this.addNewFile()
  }

  addNewFile() {
    this.filesToUpload.push(this.tempFilesToUpload);
    // this.fileToUploadControl.nativeElement.value = "";
    this.tempFilesToUpload = null;
    this.addFilesFunctionDisabled = !this.tempFilesToUpload || this.filesToUpload.length > 5;
    this.notifyFiles();
  }

  eliminarArchivo(file) {
    let indexToRemove = this.filesToUpload.indexOf(file);
    if (indexToRemove > -1) {
      this.filesToUpload.splice(indexToRemove, 1);
      this.notifyFiles();
    }
  }

  notifyFiles() {
    this.onFilesUpdated.emit(this.filesToUpload);
    this.utilRegistroService.FilesData(this.filesToUpload)
    this.filesDocumentation = []
  }
}
