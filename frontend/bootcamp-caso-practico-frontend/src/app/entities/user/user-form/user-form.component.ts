import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../service/user.service';
import { RoleDto, UserDto } from '../models/user.model';

@Component({
  selector: 'app-item-form',
  templateUrl: './user-form.component.html',
  styleUrl: './user-form.component.scss'
})
export class UserFormComponent implements OnInit {
  mode: "CREATE USER" | "UPDATE USER" = "CREATE USER";
  userId?: number;
  user?: UserDto;
  roles: RoleDto[] = [];

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const entrhParam: string = this.route.snapshot.paramMap.get("userId") ?? "new";
    if(entrhParam != "new") {
      this.userId = +this.route.snapshot.paramMap.get("userId")!;
      this.mode = "UPDATE USER"
      this.getUserById(this.userId!);
    } else {
      this.mode = "CREATE USER"
      this.initializeUser();
    }
    this.getRoles();
  }

  getUserById(userId: number) {
    this.userService.getUserById(userId).subscribe({
      next: (userRequest) => {this.user = userRequest},
      error: (err) => {this.handleError(err);}
    })
  }

  private initializeUser(){
    this.user = {
      id: undefined,       
      name: '',   
      lastName: '', 
      email: '',   
      roleId: 0,
      roleName:'',
      rowVersion: ''
    };
  }

  public getRoles(): void {
    this.userService.getRoles().subscribe({
      next:(rolesRequest) => {this.roles = rolesRequest;},
      error:(err) => {this.handleError(err);}
    })
  }

  public saveUser(): void {
    if (this.mode === "CREATE USER") {
      this.insertUser();
    }
    if (this.mode === "UPDATE USER") {
      this.updateUser();
    }
  }

  insertUser(): void {
    this.userService.insertUser(this.user!).subscribe({
      next: (userInserted) => {
        console.log("Creado correctamente");
        console.log(userInserted);
        this.router.navigate(['/']);
      },
      error: (err) => {this.handleError(err);}
    })
  }

  updateUser(): void {
    this.userService.updateUser(this.user!).subscribe({
      next: (userUpdated) => {
        console.log("Modificado correctamente");
        console.log(userUpdated);
        this.router.navigate(['/']);
      },
      error: (err) => {this.handleError(err);}
    })
  }

  goBack(): void {
    this.router.navigate(['/'])
  }

  private handleError(err: any): void {

  }
}
