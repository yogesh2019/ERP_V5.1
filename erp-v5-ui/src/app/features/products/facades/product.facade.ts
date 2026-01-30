import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable()
export class ProductFacade {
    private titleSubject = new BehaviorSubject<string>('Products');
    title$ = this.titleSubject.asObservable();
}