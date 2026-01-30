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
    product$: Observable<Product[]>
    constructor(private facade: ProductFacade) {
        this.product$ = this.facade.product$;
    }
}