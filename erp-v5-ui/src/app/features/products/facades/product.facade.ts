import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { Product } from "../product.model";
import { ProductService } from "../services/product.service";
import { nextTick } from "process";

@Injectable()
export class ProductFacade {
    private productsSubject = new BehaviorSubject<Product[]>([]);
    private loadingSubject = new BehaviorSubject<boolean>(false);
    private errorSubject = new BehaviorSubject<string | null>(null);

    product$ = this.productsSubject.asObservable();
    loading$ = this.loadingSubject.asObservable();
    error$ = this.errorSubject.asObservable();
    constructor(private service: ProductService) {
        this.loadProducts();
    }
    loadProducts(): void {
        this.loadingSubject.next(true);
        this.errorSubject.next(null);

        this.service.getProducts().subscribe(
            {
                next: product => {
                    this.productsSubject.next(product);
                    this.loadingSubject.next(false);
                },
                error: err => {
                    this.errorSubject.next(err.message);
                    this.loadingSubject.next(false);
                }
            }
        );
    }
    addProduct(name: string): void {
        this.loadingSubject.next(true);
        this.errorSubject.next(null);

        this.service.addProducts(name).subscribe({
            next: product => {
                this.productsSubject.next([
                    ...this.productsSubject.value,
                    product
                ]);
                this.loadingSubject.next(false);
            },
            error: err => {
                this.errorSubject.next(err.message);
                this.loadingSubject.next(false);
            }
        })
    }
}