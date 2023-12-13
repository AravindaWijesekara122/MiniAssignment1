import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Users } from 'src/app/shared/module/Users';
import { map } from 'rxjs';
 
@Injectable({
  providedIn: 'root'
})
export class accountService {
  private loggedIn = false;
  private tokens = 0;

  baseUrl = "https://localhost:7163/api/";
  constructor(private http : HttpClient, private route : Router) { }
 
  login(user:any){
    this.loggedIn = true;
    return this.http.post(this.baseUrl + 'users/login', user);
  }
  
}