import { Component } from "@angular/core";
import { ProductFacade } from "../../facades/product.facade";
@Component(
    {
        selector: 'app-product-list',
        standalone: true,
        templateUrl: './product-list.component.html'
    }
)
export class ProductListComponent {
    title: string;
    constructor(private facade: ProductFacade) {
        this.title = this.facade.getTitle();
    }
}