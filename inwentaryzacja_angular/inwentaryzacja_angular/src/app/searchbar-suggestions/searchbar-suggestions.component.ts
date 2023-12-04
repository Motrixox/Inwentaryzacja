import { Component, Injectable, EventEmitter, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { EmployeeService } from '../services/employee.service';
import { Employee } from "../models/employee.model";
import { EmployeeView } from "../models/employeeView.model";
import { FormsModule} from "@angular/forms";

@Component({
  selector: 'app-searchbar-suggestions',
  templateUrl: './searchbar-suggestions.component.html',
  styleUrls: ['./searchbar-suggestions.component.css']
})

export class SearchbarSuggestionsComponent {
  searchControl = '';
  searchResults: EmployeeView[] = [];
  searchResultsId: number[] = [];
  employees: Employee[] = [];
  employeesString: EmployeeView[] = [];
  employeeId?: string;

  @Output() employeeIdChange = new EventEmitter<string>();

  constructor(private itemsService: EmployeeService)
  {
    itemsService.getAllEmployees().subscribe({
      next: (items) => {
        this.employees = items;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

  getData() {
    this.employees.forEach(element => {
      this.employeesString.push({id : element.id, fullName : element.firstName + ' ' +  element.lastName});
    });
  }

  onChange(value: string) {
    if(this.employeesString.length == 0)
    {
      this.getData();
    }

    this.employeeId = undefined;

    this.employeesString.forEach(element => {
      if(element.fullName === value)
      {
        this.employeeId = element.id.toString();
        this.employeeIdChange.emit(this.employeeId);
      }
    });

    const filterValue = value.toLowerCase();
    this.searchResults = this.employeesString.filter(option => option.fullName.toLowerCase().includes(filterValue));
  }


}
