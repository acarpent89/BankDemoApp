import { Component } from '@angular/core';


@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
})

export class TransactionComponent {
  type: string;
  amount: number;
  accountId: number;
  comments: string;
}
