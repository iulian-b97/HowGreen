import { MediaMatcher } from "@angular/cdk/layout";

export class Appliance {
    Id: string;
    ApplianceType: string;
    nrWatts: number;
    hh: number;
    mm: number;
    kwMonth: number;
    priceMonth: number;

    constructor(
        _Id: string,
        _ApplianceType: string,
        _nrWatts: number,
        _hh: number,
        _mm: number,
        _kwMonth: number,
        _priceMonth: number
    ) 
    {
        this.Id = _Id,
        this.ApplianceType = _ApplianceType,
        this.nrWatts = _nrWatts,
        this.hh = _hh,
        this.mm = _mm,
        this.kwMonth = _kwMonth,
        this.priceMonth = _priceMonth
    }
}