import { Component, OnInit } from '@angular/core';
import { PagedList, UserDto } from '../models/user.model';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.scss'
})
export class UserListComponent implements OnInit {

  users: UserDto[] = [];
  currentPage: number = 1;
  totalPages: number = 0;
  pageSize: number = 10;
  totalCount: number = 0;

  nameFilter?: string;
  priceFilter?: number;

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.getAllUsers();
  }

  public nextPage(): void {
    this.currentPage += 1;
    this.getAllUsers();
  }

  public previousPage(): void {
    this.currentPage -= 1;
    this.getAllUsers(); 
  }

  public searchByFilter(): void {
    
  }

  private getAllUsers(): void {
    this.userService.getAllUsers(this.currentPage, this.pageSize).subscribe({
      next: (data: PagedList<UserDto>) => {
        this.users = data.data;
        this.currentPage = data.currentPage;
        this.totalPages = data.totalPages;
        this.pageSize = data.pageSize;
        this.totalCount = data.totalCount;
      },
      error: (err) => {this.handleError(err);}
    });
  }

  private handleError(error:any): void {
    console.log(error);
  }
}
