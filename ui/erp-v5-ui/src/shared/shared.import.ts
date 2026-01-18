import { CommonModule } from "@angular/common";
import { MATERIAL_IMPORTS } from "./materials/material.import";

export const SHARED_IMPORTS = [
    CommonModule,
    ...MATERIAL_IMPORTS
]