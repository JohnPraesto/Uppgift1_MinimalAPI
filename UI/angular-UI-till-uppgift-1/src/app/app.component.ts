import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Book } from './Models/Book';
import { APIResponse } from './Models/APIResponse';
import { BookService } from './Service/library.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, CommonModule, HttpClientModule, RouterLink], // vilka av de här används ens?
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'angular-UI-till-uppgift-1';

  books : Book[] = []; // Behövs denna... 
  booksFromAPIResponse : APIResponse["result"] = []; // ... eller denna?

  // Försöker ta in Single Book . behöver en APIresponse här också?
  book : Book = {
    bookId: '',
    title: '',
    author: '',
    genre: '',
    published: '',
    isAvailable: false
  }

  constructor(private bookservice:BookService){}

  getAllBooks(){
    this.bookservice.getAllBooks().subscribe(response => {this.books = response})
  }

  ngOnInit():void{
    this.getAllBooks();
  }

  updateBook(book:Book){
    this.bookservice.updateBook(book).subscribe(response => this.getAllBooks())
  }

  onSubmit(){
    if(this.book.bookId == ''){
      this.bookservice.addBook(this.book).subscribe(response => {
        this.getAllBooks()
        this.book = {
          bookId: '',
          title: '',
          author: '',
          genre: '',
          published: '',
          isAvailable: false
        }
      })
    }
    else{
      this.updateBook(this.book)
    }
  }

  onDelete(id:string){ // string eller int får man vaksam på
    this.bookservice.deleteBook(id).subscribe(response => this.getAllBooks())
  }

  populateForm(book:Book){
    this.book = book
  }
}

