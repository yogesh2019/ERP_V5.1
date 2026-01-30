import { NgModule } from "@angular/core";
import { ProductListComponent } from "./components/product-list.component";
import { CommonModule } from "@angular/common";
import { ProductsRoutingModule } from "./product-routing.module";
import { ProductFacade } from "./facades/product.facade";
import { FormsModule } from "@angular/forms";
import { ProductService } from "./services/product.service";

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
        ProductFacade,
        ProductService
    ]
})
export class ProductModule {

}