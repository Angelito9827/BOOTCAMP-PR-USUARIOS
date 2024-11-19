import { Injectable } from '@angular/core';
import { PagedList, UserDto } from '../models/user.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) {}   

  public getAllUsers(page: number, size: number): Observable<PagedList<UserDto>>{
    const urlEndpoint: string = "https://localhost:7179/users?PageNumber=" + page + "&PageSize=" + size;
    return this.http.get<PagedList<UserDto>>(urlEndpoint);
  }
}
