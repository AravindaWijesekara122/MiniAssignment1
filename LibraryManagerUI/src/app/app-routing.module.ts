import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { BookListComponent } from './components/book-list/book-list.component';
import { LoginComponent } from './components/account/login/login.component';
 
const routes: Routes = [
   
  {path:'', loadChildren: ()=>import('./components/account/account/account.module').then(l=>l.AccountModule)},
  {path:'home', component:HomeComponent},
  {path:'login', component:LoginComponent},
  {path:'book-list', component:BookListComponent},
  {path:'**',redirectTo:'',pathMatch:'full'}
];
 
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }