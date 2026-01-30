import { Component } from "@angular/core";
import { ProductFacade } from "../facades/product.facade";
import { Observable } from "rxjs";
import { Product } from "../product.model";

@Component(
    {
        selector: 'app-product-lit',
        templateUrl: './product-list.component.html'
    }
)
export class ProductListComponent {
    product$ = this.facade.product$;
    loading$ = this.facade.loading$;
    error$ = this.facade.error$;
    newProductName = '';
    constructor(private facade: ProductFacade) {
    }
    add(): void {
        if (!this.newProductName.trim()) {
            return;
        }
        this.facade.addProduct(this.newProductName);
        this.newProductName = '';
    }
}