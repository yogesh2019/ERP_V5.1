import { Injectable } from "@angular/core";
import { Product } from "../product.model";
import { delay, Observable, of, throwError } from "rxjs";

@Injectable()
export class ProductService {
    private products: Product[] = [
        { id: 1, name: "Keyboard" },
        { id: 2, name: "Mouse" },
        { id: 3, name: "Monitor" }
    ];
    getProducts(): Observable<Product[]> {
        return of(this.products).pipe(delay(800));
    }
    addProducts(nameProduct: string): Observable<Product> {
        if (nameProduct.toLowerCase() === "error") {
            return throwError(() => new Error('Invalid product name')).pipe(delay(500));
        }
        const product: Product = {
            id: this.products.length + 1,
            name: nameProduct
        };
        this.products = [...this.products, product];
        return of(product).pipe(delay(500));
    }
}