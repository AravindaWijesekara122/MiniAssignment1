import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { LoginComponent } from '../login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AccountRoutingModule } from '../account-routing/account-routing.module';
import { BookListComponent } from '../../book-list/book-list.component';
  
 
@NgModule({
  declarations: [
    LoginComponent,
    BookListComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    ReactiveFormsModule
      
  ]
})
export class AccountModule { }