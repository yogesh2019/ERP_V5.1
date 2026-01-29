import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { ProductListComponent } from './features/products/components/product-list/product-list.component';

export const routes: Routes = [
    {
        path: '',
        component: MainLayoutComponent,
        children: [
            {
                path: 'products',
                component: ProductListComponent
            }

        ]
    }
];
