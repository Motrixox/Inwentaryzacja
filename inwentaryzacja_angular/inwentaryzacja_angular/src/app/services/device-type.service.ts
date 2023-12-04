import { Injectable } from '@angular/core';
import { DeviceType } from '../models/deviceType.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DeviceTypeService {
  private apiBaseUrl = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getAllDeviceTypes(): Observable<DeviceType[]>{
    return this.http.get<DeviceType[]>(
      `${this.apiBaseUrl}/api/DeviceTypes`, 
      { withCredentials: true }
      );
  }
}
