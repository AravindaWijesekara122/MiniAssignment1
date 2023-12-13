import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { accountService } from '../account.service';
import { Users } from 'src/app/shared/module/Users';
 
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
 
  title : string ='Login From';

  loginForm = new FormGroup({
    username : new FormControl('',Validators.required),
    password: new FormControl('',Validators.required)
  })

  user: Users = {
    name : '',
    username : '',
    password: '',
    tokensAvailable : 0,
    booksBorrowed : [],
    booksLent : []    
  }

  constructor(private accountService: accountService, private router: Router){}
 
  onSubmit(){
    this.user.username = this.loginForm.value.username;
    this.user.password = this.loginForm.value.password;

    if (this.user.username != null && this.user.password) {
      this.accountService.login(this.user).subscribe({
        next:()=> {
          console.log('Login successful.');
          this.router.navigateByUrl('/book-list');
        },
        error:(err)=> {
          console.log("Unable to login", err);
          alert("Please check Credential...!") 
        }
      })
      this.router.navigateByUrl('/home');  
    }
    else{
      alert("Username or Password is empty");
    }
    
  }
}