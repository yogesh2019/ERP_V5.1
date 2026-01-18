import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SHARED_IMPORTS } from '../../../../shared/shared.import';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [RouterOutlet, SHARED_IMPORTS],
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css']
})
export class MainLayoutComponent { }
