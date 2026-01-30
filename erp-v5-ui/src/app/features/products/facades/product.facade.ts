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
    private loadingSubject = new BehaviorSubject<boolean>(false);
    private errorSubject = new BehaviorSubject<string | null>(null);

    product$ = this.productsSubject.asObservable();
    loading$ = this.loadingSubject.asObservable();
    error$ = this.errorSubject.asObservable();
    addProduct(name: string): void {
        this.loadingSubject.next(true);
        this.errorSubject.next(null);
        setTimeout(() => {
            if (name.toLowerCase() === "error") {
                this.errorSubject.next("Invalid product name");
                this.loadingSubject.next(false);
                return;
            }
            const current = this.productsSubject.value;
            const newProduct: Product = {
                id: current.length + 1,
                name
            }
            this.productsSubject.next([...current, newProduct])
            this.loadingSubject.next(false);
        }, 800);
    }
}