import { Component } from '@angular/core';
import { Device, Status } from '../models/device.model';
import { DeviceService } from '../services/device.service';
import { Html5QrcodeScanner } from 'html5-qrcode';

@Component({
  selector: 'app-scanner',
  templateUrl: './scanner.component.html',
  styleUrls: ['./scanner.component.css']
})
export class ScannerComponent {
  html5QrcodeScanner?: Html5QrcodeScanner;

  //item: Device = {id: 1, deviceType: {id: 1, type:''}, serialNumber: '', description: '', code: '', employeeId:1};
  item: Device | undefined;
  result: string = '';
  itemFound: boolean = false;
  hasResult: boolean = false;
  message: string = "Oczekiwanie na zeskanowanie kodu...";
  
  successMessage: string = '';
  failMessage: string = '';

  // onScanSuccess(decodedText: string, decodedResult: any) {
  //   console.log(`Code matched = ` + decodedText, decodedResult);
  //   this.handleCodeResult(decodedText);
  // }
  
  onScanFailure(error: any) {
    //console.warn(`Code scan error = ${error}`);
  }

  ngAfterViewInit(){
    this.html5QrcodeScanner = new Html5QrcodeScanner(
      'reader',
      { fps: 5, qrbox: {width: 250, height: 250} },
      /* verbose= */ false);

    this.html5QrcodeScanner.render(this.handleCodeResult.bind(this), this.onScanFailure);
  }

  constructor(private deviceService: DeviceService){
    
  }

  handleCodeResult(result: string): void {
    console.log('Result: ', result);
    //this.successMessage = 'Zeskanowano pomyślnie. Wynik: ' + result;
    document.getElementById('scannerInput')?.setAttribute("value", result);
    this.result = result;
    
    if(result != null)
    {
      this.deviceService.getDeviceByCode(result)
      .subscribe({
        next: (items) => {
          console.log(items.description);
          console.log(items);
          this.item = items;
          this.itemFound = true;
          this.hasResult = true;
          this.message = "Przedmiot znaleziony w bazie danych!";
        },
        error: (response) => {
          console.log(response);
          this.itemFound = false;
          this.hasResult = true;
          this.message = "Przedmiot nie został znaleziony w bazie danych.";
        }
      });
    }
  }

  onCloseAlert(mode: string){
    switch (mode) {
      case 'succ':
        this.successMessage = '';
        break;

        case 'fail':
          this.failMessage = '';
          break;  
    
      default:
        break;
    }
  }

  onSuccessEmitted(success: string){
    this.failMessage = '';
    this.successMessage = success;
  }

  onFailEmitted(fail: string){
    this.successMessage = '';
    this.failMessage = fail;
  }
}
