import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { SideBarComponent } from "../sidebar/sidebar.component";

@Component(
    {
        selector: 'app-main-layout',
        standalone: true,
        imports: [RouterOutlet, SideBarComponent],
        templateUrl: './main-layout.component.html'
    }
)
export class MainLayoutComponent {

}