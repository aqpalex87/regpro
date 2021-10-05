import {Injectable} from '@angular/core';
import Swal from 'sweetalert2'
import * as moment from 'moment';

@Injectable()
export class Utilfunctions {

  constructor() {}

  public ValidateFile(file,types,length) {
    var accettype = "0";
    var arreglo = types;
    let tamfoto: number = file.size;
    let tampred: number =  length;

    for (var i = 0; i < arreglo.length; i++) {
        if (arreglo[i] === file.type) {
            accettype = "1";
            break;
        }
    }

    if (accettype === "0") {
        Swal.fire(
          'Archivo',
          'La extensión del archivo es incorrecta.',
          'error'
        )
        return false;
    }

    if (tamfoto > tampred ) {
        Swal.fire(
          'Archivo',
          'El archivo excede el tamaño máximo permitido.',
          'error'
        )
        return false;
    }
    return true;
  }

  public isEmptyObject(obj) {
    return Object.getOwnPropertyNames(obj).length === 0;
  }

  public returnFecha(): string {
    let fecha = new Date()
    return this.returnDiaOMes(fecha.getFullYear()) + "-" + this.returnDiaOMes(fecha.getMonth()) + "-" + this.returnDiaOMes(fecha.getDate())
  }

  returnDiaOMes(param: number): string{
    if(param<10){
      return "0"+param
    }else{
      return String(param)
    }
  }

}
