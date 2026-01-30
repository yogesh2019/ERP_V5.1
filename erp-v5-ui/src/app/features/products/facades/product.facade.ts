import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { Product } from "../product.model";

@Injectable()
export class ProductFacade {
    private productsSubject = new BehaviorSubject<Product[]>(
        [
            { id: 1, name: "Keyboard" },
            { id: 2, name: "Mouse" },
            { id: 3, name: "Monitor" }
        ]
    );
    product$ = this.productsSubject.asObservable();
}