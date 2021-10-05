import { Component, EventEmitter , ElementRef,Input, Output, OnInit, ViewChild, ChangeDetectorRef, SimpleChange } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Utilfunctions } from "src/app/services/util-functions.service";

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})
export class UploadFileComponent implements OnInit {

  @Input() multiple: boolean = false;
  @Input() accept: string = "*";
  @Input() fileInput: any = null;
  @Input() types: string[] = ["*"];
  @Input() tamanioFile: number = 1 * 1024 * 1024;

  @ViewChild('dropZone') dropZone;
  @ViewChild('uploadFile') uploadFile: ElementRef<HTMLInputElement>;
  @Input() files: any = [];
  @Input() blockLoad : boolean = false;
  @Output() valueChange = new EventEmitter<any>();

  uploadFileForm = new FormGroup({
    fileName:new FormControl(null)
  })

  constructor(
    private changeDetector: ChangeDetectorRef,
    private _utilfunctions: Utilfunctions
  ) { }

  ngOnInit(): void {

  }

  ngOnChanges(changes: SimpleChange) {
      if(this.fileInput !== null){
          this.files.push(this.fileInput);
          this.changeDetector.markForCheck();
      }
  }

  onFileDropped($event) {
    if (this.multiple) {
      this.files.push(...$event);
    } else {
      this.files = $event;
    }
  }

  upload(file:any): void {
    const newFiles = Array.from(file.target.files);

    if (this.multiple) {
      this.files.push(...newFiles);
      this.valueChange.emit(this.files);
    } else {
        if(this._utilfunctions.ValidateFile(newFiles[0],this.types,this.tamanioFile)){
            this.files = newFiles;
            this.uploadFile.nativeElement.value = '';
            this.valueChange.emit(this.files);
        }
    }
  }

  removeFile(index): void {
      if(!this.blockLoad){
        this.files.splice(index, 1);
      }
  }
}
