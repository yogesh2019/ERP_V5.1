import { Component } from "@angular/core";
import { ProductFacade } from "../facades/product.facade";

@Component(
    {
        selector: 'app-product-lit',
        templateUrl: './product-list.component.html'
    }
)
export class ProductListComponent {
    title$ = this.facade.title$;
    constructor(private facade: ProductFacade) {

    }
}