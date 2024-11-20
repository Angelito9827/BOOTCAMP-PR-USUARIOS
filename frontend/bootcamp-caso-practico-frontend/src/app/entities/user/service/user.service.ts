import { Injectable } from '@angular/core';
import { PagedList, RoleDto, UserDto } from '../models/user.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) {}   

  public getAllUsers(page: number, size: number, filters?: string): Observable<PagedList<UserDto>>{
    let urlEndpoint: string = "https://localhost:7179/users?PageNumber=" + page + "&PageSize=" + size;
    if (filters) {
      urlEndpoint = urlEndpoint + "&filter=" + filters;
    }
    return this.http.get<PagedList<UserDto>>(urlEndpoint);
  }

  public getUserById(userId: number): Observable<UserDto> {
    let urlEndpoint: string = "https://localhost:7179/users/" + userId;
    return this.http.get<UserDto>(urlEndpoint);
  }

  public getRoles(): Observable<RoleDto[]> {
    let urlEndpoint: string = "https://localhost:7179/roles";
    return this.http.get<RoleDto[]>(urlEndpoint);
  }

  public deleteUser(userIdToDelete: number): Observable<any> {
    let urlEndpoint: string = "https://localhost:7179/users/" + userIdToDelete;
    return this.http.delete<any>(urlEndpoint);
  }

  public insertUser(user: UserDto): Observable<UserDto> {
    let urlEndpoint: string = "https://localhost:7179/users/";
    return this.http.post<UserDto>(urlEndpoint, user);
  }

  public updateUser(user: UserDto): Observable<UserDto> {
    let urlEndpoint: string = "https://localhost:7179/users/";
    return this.http.put<UserDto>(urlEndpoint, user);
  }
}
