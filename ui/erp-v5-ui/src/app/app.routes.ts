import { Routes } from '@angular/router';
import { MainLayoutComponent } from './core/layout/main-layout/main-layout.component';

export const routes: Routes = [
    {
        path: '',
        component: MainLayoutComponent,
        children: [
            {
                path: 'products',
                loadChildren: () =>
                    import('./features/products/products.routes')
                        .then(m => m.PRODUCT_ROUTES)
            },
            {
                path: 'inventory',
                loadChildren: () =>
                    import('./features/inventory/inventory.routes')
                        .then(m => m.INVENTORY_ROUTES)
            },
            {
                path: 'planning',
                loadChildren: () =>
                    import('./features/planning/planning.routes')
                        .then(m => m.PLANNING_ROUTES)
            },
            {
                path: '',
                redirectTo: 'products',
                pathMatch: 'full'
            }
        ]
    }
];
