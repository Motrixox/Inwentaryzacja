import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from "./app-routing.module";
import {AppComponent} from "./app.component";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {HeaderComponent} from './header/header.component';
import {ZXingScannerModule} from '@zxing/ngx-scanner';
import {ScannerComponent} from './scanner/scanner.component';
import {QRCodeModule} from 'angularx-qrcode';
import {IssueDeviceModalComponent} from './issue-device-modal/issue-device-modal.component';
import {SearchbarSuggestionsComponent} from './searchbar-suggestions/searchbar-suggestions.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatInputModule} from '@angular/material/input';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatCheckboxModule} from "@angular/material/checkbox";
import {MatTableModule} from "@angular/material/table";
import {MatSortModule} from "@angular/material/sort";
import {ReturnDeviceModalComponent} from './return-device-modal/return-device-modal.component';
import { InventoryDeviceComponent } from './inventory-device/inventory-device.component';
import { AddDeviceScannerModalComponent } from './add-device-scanner-modal/add-device-scanner-modal.component';
import { TurnOffModalComponent } from './turn-off-modal/turn-off-modal.component';

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        ScannerComponent,
        IssueDeviceModalComponent,
        SearchbarSuggestionsComponent,
        ReturnDeviceModalComponent,
        InventoryDeviceComponent,
        AddDeviceScannerModalComponent,
        TurnOffModalComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        ZXingScannerModule,
        QRCodeModule,
        FormsModule,
        MatInputModule,
        MatAutocompleteModule,
        BrowserAnimationsModule,
        MatCheckboxModule,
        MatTableModule,
        MatSortModule
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}
