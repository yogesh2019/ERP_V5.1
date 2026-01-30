import { NgModule } from "@angular/core";
import { ProductListComponent } from "./components/product-list.component";
import { CommonModule } from "@angular/common";
import { ProductsRoutingModule } from "./product-routing.module";
import { ProductFacade } from "./facades/product.facade";

@NgModule({
    declarations: [
        ProductListComponent
    ],
    imports: [
        CommonModule,
        ProductsRoutingModule
    ],
    providers: [
        ProductFacade
    ]
})
export class ProductModule {

}