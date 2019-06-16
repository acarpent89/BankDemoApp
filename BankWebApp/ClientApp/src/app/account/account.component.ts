import { Component } from '@angular/core';



@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
})


export class AccountComponent {
    type: string;
    employeeId: number;
    creditLimit: number;
    customerId: number;
    createdDate: string;
    activeFlag: string;
    comments: string;
}
