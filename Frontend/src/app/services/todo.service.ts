import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  private myAppUrl = 'https://localhost:5001/';
  private myApiUrl = 'api/Todo/';
  private descUrl = 'descripcion/';
  private stateUrl = 'estado/';

  constructor(private http: HttpClient) {}

  getListTodo(): Observable<any> {
    return this.http.get(this.myAppUrl + this.myApiUrl);
  }

  getTodoById(id: number): Observable<any> {
    return this.http.get(this.myAppUrl + this.myApiUrl + id);
  }

  getTodosByDesc(desc: String): Observable<any> {
    return this.http.get(this.myAppUrl + this.myApiUrl + this.descUrl + desc);
  }

  getTodosByState(state: String): Observable<any> {
    return this.http.get(this.myAppUrl + this.myApiUrl + this.stateUrl + state);
  }

  deleteTodo(id: number): Observable<any> {
    return this.http.delete(this.myAppUrl + this.myApiUrl + id);
  }
  createTodo(todo: any): Observable<any> {
    return this.http.post(this.myAppUrl + this.myApiUrl, todo);
  }
  updateTodo(id: number, todo: any): Observable<any> {
    return this.http.put(this.myAppUrl + this.myApiUrl + id, todo);
  }
}
