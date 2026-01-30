import { Injectable } from "@angular/core";
import { BehaviorSubject, catchError, EMPTY, finalize, tap } from "rxjs";
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

        this.service.getProducts().pipe(
            tap(
                products => {
                    this.productsSubject.next(products);
                }
            ),
            catchError(err => { this.errorSubject.next(err.message); return EMPTY }),
            finalize(() => this.loadingSubject.next(false))
        ).subscribe(

        );
    }
    addProduct(name: string): void {
        this.loadingSubject.next(true);
        this.errorSubject.next(null);

        this.service.addProducts(name).pipe(
            tap(
                product => {
                    this.productsSubject.next([
                        ...this.productsSubject.value,
                        product
                    ])
                }
            ),
            catchError(err => {
                this.errorSubject.next(err.message);
                return EMPTY;
            }),
            finalize(() => this.loadingSubject.next(false))
        ).subscribe({

        })
    }
}