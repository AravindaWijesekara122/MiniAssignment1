import { Component, OnInit, inject } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit{
  constructor(private router: Router){}

  httpClient = inject(HttpClient)
  data: any[] = [];

  ngOnInit(): void {
    this.fetchBookList();
  }
  
  fetchBookList(){

    let url = 'https://localhost:7163/api/books/available';
    this.httpClient.get(url).subscribe((data: any) => {
      console.log(data);
      this.data = data;
    });
  }

  logout() {
    this.router.navigate(['/home']);
  }

}
