import { HttpClient } from "@angular/common/http"
import { APIResponse } from "../Models/APIResponse"
import { Book } from "../Models/Book"
import { Injectable } from "@angular/core"
import { map, Observable } from "rxjs"

@Injectable({
    providedIn: 'root'
})

export class BookService{
    constructor(private http:HttpClient){ }

    getAllBooks():Observable<Book[]>{
        return this.http.get<APIResponse>('https://localhost:7242/api/books').pipe(
            map((response:APIResponse) => response.result as Book[])
        )
    }

    updateBook(book: Book): Observable<Book>{
        return this.http.put<APIResponse>('https://localhost:7242/api/book', book).pipe(
            map((response: APIResponse) => response.result as Book)
        );
    }

    addBook(book:Book): Observable<Book>{
        return this.http.post<APIResponse>('https://localhost:7242/api/book', book).pipe(
            map((response: APIResponse) => response.result as Book)
        );
    }

    deleteBook(id:string):Observable<Book>{
        return this.http.delete<APIResponse>('https://localhost:7242/api/book/' + id).pipe(
            map((response:APIResponse) => response.result as Book)
        )
    }
}

