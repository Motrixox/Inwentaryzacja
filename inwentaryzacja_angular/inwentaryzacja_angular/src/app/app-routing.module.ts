import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { ScannerComponent } from './scanner/scanner.component';

const routes: Routes = [
    {path: '', redirectTo: '/index.html', pathMatch: 'full'},
    {path: 'scanner', component:ScannerComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
