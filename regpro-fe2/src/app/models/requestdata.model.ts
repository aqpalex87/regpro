import {Injectable} from '@angular/core';
import { MasterModel } from "./master.model";

@Injectable()
export class RequestDataModel {
    typeManagements: MasterModel[];
    typePrograms: MasterModel[];
    typeDependencies: MasterModel[];
    typeManagingEntitys: MasterModel[];
    typeAvenues: MasterModel[];
    typeLocation: MasterModel[];
    typeDocuments: MasterModel[];
    typeShift: MasterModel[];
    typeContinuity: MasterModel[];
    typeWaterProvider: MasterModel[];
    typeEnergyProvider: MasterModel[];
}
