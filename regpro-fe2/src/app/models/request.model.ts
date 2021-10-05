import {Injectable} from '@angular/core';

@Injectable()
export class RequestModel {
    id: number;
    modularCode: string;
    idTypeProgram: number;
    idTypeManagement: number;
    idTypeDependency: number;
    idTypeAvenue: number;
    addressName: string;
    addressNumber: string;
    adressBlock: string;
    addressLot: string;
    idTypeLocation: number;
    addressLocation: string;
    codeGeoLocalization: string;
    geolocalizationHash: string;
    codeVillageCentre: string;
    nameVillageCentre: string;
    latitudeVillageCentre: number;
    longitudeVillageCentre: number;
    latitudeNearestEducationalCentre: number;
    longitudeNearestEducationalCentre: number;
    codeWaterProvider: number;
    waterSupplyNumber: string;
    codeEnergyProvider: number;
    energySupplyNumber: string;
    idTypeShift: number;
    idTypeContinuity: number;
    userCreator: string;
    dateCreation: Date;
    userModifier: string;
    dateModification: Date;
    status: string;

    programLatitude: number;
    programLongitude: number;
    ID_TIPEGES: number;

    public constructor(init?:Partial<RequestModel>) {
        Object.assign(this, init);
    }
}
