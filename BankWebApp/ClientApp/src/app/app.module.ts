import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CustomerComponent} from './customer/customer.component';
import { CustomersComponent } from './customer/customers.component';
import { Customer } from './customer/customer';
import { CustomerService } from './customer/customer.service';
import { AccountComponent } from './account/account.component';
import { TransactionComponent } from './transaction/transaction.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CustomerComponent,
    CustomersComponent,
    TransactionComponent,
    AccountComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'customer/:id', component: CustomerComponent },
      { path: 'customers', component: CustomersComponent },
      { path: 'transaction', component: TransactionComponent },
      { path: 'account', component: AccountComponent },
    ])
  ],
  providers: [CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
