import { NgModule } from "@angular/core";
import { ProductListComponent } from "./components/product-list.component";
import { CommonModule } from "@angular/common";
import { ProductsRoutingModule } from "./product-routing.module";
import { ProductFacade } from "./facades/product.facade";
import { FormsModule } from "@angular/forms";

@NgModule({
    declarations: [
        ProductListComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ProductsRoutingModule
    ],
    providers: [
        ProductFacade
    ]
})
export class ProductModule {

}