import {Injectable, Output, EventEmitter} from '@angular/core';
import {Observable} from 'rxjs';

@Injectable({ providedIn: "root" })
export class UtilRegistroService {
  constructor() {}

  isProgramData: any;
  @Output() changeProgramData: EventEmitter<any> = new EventEmitter();

  public ProgramData(data: any) {
    this.isProgramData = data;
    this.changeProgramData.emit(this.isProgramData);
  }
  public viewProgramData(){
    return this.isProgramData;
  }

  isCroquisData: any;
  @Output() changeCroquisData: EventEmitter<any> = new EventEmitter();

  public CroquisData(data: any) {
    this.isCroquisData = data;
    this.changeCroquisData.emit(this.isCroquisData);
  }
  public viewCroquisData(){
    return this.isCroquisData;
  }

  isFilesData: any;
  @Output() changeFilesData: EventEmitter<any> = new EventEmitter();

  public FilesData(data: any) {
    this.isFilesData = data;
    this.changeFilesData.emit(this.isFilesData);
  }
  public viewFilesData(){
    return this.isFilesData;
  }

}
