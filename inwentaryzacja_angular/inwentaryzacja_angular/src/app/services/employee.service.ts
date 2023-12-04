import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Employee } from "../models/employee.model";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment";

@Injectable({
    providedIn: "root",
})
export class EmployeeService {
    private apiBaseUrl = environment.baseApiUrl;

    constructor(private http: HttpClient) {}

    getAllEmployees(): Observable<Employee[]> {
        return this.http.get<Employee[]>(
            `${this.apiBaseUrl}/api/Employees`,
            { withCredentials: true }
        );
    }

    addEmployee(addEmployeeForm: Employee): Observable<Employee> {
        return this.http.post<Employee>(
            `${this.apiBaseUrl}/api/Employees`,
            addEmployeeForm,
            { withCredentials: true }
        );
    }

    editEmployee(editEmployeeForm: Employee): Observable<Employee>{
        editEmployeeForm.devices = null;
        return this.http.put<Employee>(
            `${this.apiBaseUrl}/api/Employees`,
            editEmployeeForm,
            {withCredentials: true}
        );
    }
}
