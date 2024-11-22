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
  userIdToDelete?: number;
  nameFilter?: string;
  lastNameFilter?: string;
  roleFilter?: string;
  notFound: boolean = false;
  loadError: boolean = false;

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
    this.getAllUsers();
  }

  resetFilter(): void {
    this.nameFilter = "";
    this.lastNameFilter = "";
    this.roleFilter = "";
    this.searchByFilter();
  }

  builFilters(): string|undefined {
    const filters:string[] = [];

    if(this.nameFilter) {
      filters.push("name:MATCH:" + this.nameFilter)
    }

    if(this.lastNameFilter) {
      filters.push("name:MATCH:" + this.lastNameFilter)
    }

    if(this.roleFilter) {
      filters.push("role.name:MATCH:" + this.roleFilter)
    }
    
    if(filters.length > 0){
      let globalFilters: string = "";
      for (let filter of filters) {
        globalFilters = globalFilters + filter + ",";
      }
      globalFilters = globalFilters.substring(0, globalFilters.length-1);
      return globalFilters;
    } else {
        return undefined;
      }
  }

  private getAllUsers(): void {

    const filters:string | undefined = this.builFilters();

    this.userService.getAllUsers(this.currentPage, this.pageSize, filters).subscribe({
      next: (data: PagedList<UserDto>) => {
        this.users = data.data;
        this.currentPage = data.currentPage;
        this.totalPages = data.totalPages;
        this.pageSize = data.pageSize;
        this.totalCount = data.totalCount;
        this.notFound = this.users.length === 0;
      },
      error: (err) => {this.handleError(err);
        this.loadError =  true;
      }
    });
  }

  public prepareUserToDelete(userId?: number): void {
    if (userId !== undefined) {
      this.userIdToDelete = userId;
    }
  }

  public deleteUser(): void {
    if (this.userIdToDelete) {
      this.userService.deleteUser(this.userIdToDelete).subscribe({
        next: (data) => {this.getAllUsers();
        },
        error: (err) => {this.handleError(err);
        }
      });
    }
  }

  private handleError(error:any): void {
    console.log(error);
  }
}
