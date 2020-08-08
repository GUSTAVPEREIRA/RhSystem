import { Injectable, PLATFORM_ID, Inject } from '@angular/core';
import {isPlatformBrowser} from '@angular/common'

@Injectable({
    providedIn: 'root'
})
export class PlatFormDetectorService {

    constructor(@Inject(PLATFORM_ID) private platFormId: string) {

    }
 
    isPlatFormBrowser() {
        return isPlatformBrowser(this.platFormId);
    }
}