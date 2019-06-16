import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer/customer.service';
import { Customer } from '../customer/customer';


@Component({
  selector: 'app-customer',
  templateUrl: './customers.component.html',
})


export class CustomersComponent implements OnInit {
  customers: Array<Customer> = new Array<Customer>();
  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe((res) => {
      this.customers = res;
    });
  }
}
