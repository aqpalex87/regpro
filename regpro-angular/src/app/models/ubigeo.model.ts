import {Injectable} from '@angular/core';
import { DistrictModel } from "./district.model";
import { ProvinceModel } from "./province.model";
import { RegionModel } from "./region.model";

@Injectable()
export class UbigeoModel {
    regions: RegionModel[];
    provinces: ProvinceModel[];
    districts: DistrictModel[];
}
