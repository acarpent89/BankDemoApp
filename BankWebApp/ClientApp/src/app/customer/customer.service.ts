import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../customer/customer'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  apiURL: string = window.location.origin + '/api/';


  constructor(private httpClient: HttpClient) {

  }

  public createCustomer(customer: Customer) {
    return this.httpClient.post(`${this.apiURL}customer/create`, customer);
  }

  public updateCustomer(customer: Customer) {
    return this.httpClient.post(`${this.apiURL}customer/update`, customer);
  }

  public deleteCustomer(id: number) { }

  public getCustomerById(id: number) {
    return this.httpClient.get<Customer>(`${this.apiURL}customer/` + id);
  }

  public getCustomers(){
    return this.httpClient.get<Array<Customer>>(`${this.apiURL}customers`);
  }
}
