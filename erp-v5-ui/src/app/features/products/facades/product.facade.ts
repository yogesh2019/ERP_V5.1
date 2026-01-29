import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class ProductFacade {
    getTitle(): string {
        return "Products";
    }
}