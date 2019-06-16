import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer/customer.service';
import { Customer } from '../customer/customer';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
})


export class CustomerComponent implements OnInit {
  customer: Customer;
  id: number;
  private sub: any;
  constructor(private customerService: CustomerService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.customer = new Customer();

    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number
      this.customer.customerId = this.id;
      if (this.id > 0) {
        this.customerService.getCustomerById(this.id).subscribe((res) => {
          this.customer = res;
        });
      }
      // In a real app: dispatch action to load the details here.
    });
  }

  addCustomer() {
    this.customerService.createCustomer(this.customer).subscribe((res) => {
      console.log(res);
    });
  }

  updateCustomer() {
    this.customerService.updateCustomer(this.customer).subscribe((res) => {
      console.log(res);
    });
  }

  getCustomers() {
    this.customerService.getCustomers().subscribe((res) => {
      console.log(res);
    });
  }
}
