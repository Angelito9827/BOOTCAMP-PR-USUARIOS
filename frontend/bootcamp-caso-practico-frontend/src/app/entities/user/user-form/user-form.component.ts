import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../service/user.service';
import { RoleDto, UserDto } from '../models/user.model';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';

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
  form?: FormGroup;
  errorMessage: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private router: Router,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.buildForm();
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
      next: (userRequest) => {this.user = userRequest;
        this.updateForm(userRequest);
      },
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
    this.form?.patchValue(this.user);
  }

  public getRoles(): void {
    this.userService.getRoles().subscribe({
      next:(rolesRequest) => {this.roles = rolesRequest;},
      error:(err) => {this.handleError(err);}
    })
  }

  public saveUser(): void {
    if (this.form?.invalid) {
      return;
    }
    const userToSave: UserDto = this.createFromForm();
    if (this.mode === "CREATE USER") {
      this.insertUser(userToSave);
    }
    if (this.mode === "UPDATE USER") {
      this.updateUser(userToSave);
    }
  }

  insertUser(userToSave: UserDto): void {
    this.userService.insertUser(userToSave).subscribe({
      next: (userInserted) => {
        console.log("Created successfully");
        console.log(userInserted);
        this.router.navigate(['/']);
      },
      error: (err) => {this.handleError(err);}
    })
  }

  updateUser(userToSave: UserDto): void {
    this.userService.updateUser(userToSave).subscribe({
      next: (userUpdated) => {
        console.log("Updated successfully");
        console.log(userUpdated);
        this.router.navigate(['/']);
      },
      error: (err) => {this.handleError(err);}
    })
  }

  goBack(): void {
    this.router.navigate(['/'])
  }

  public buildForm(): void {
    this.form = this.formBuilder.group({
      id: [{ value: undefined, disabled: true }],
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      email: ['', [
        Validators.required,
        Validators.email,
        Validators.minLength(5),
        Validators.maxLength(100)
      ]],
      roleId: ['',[Validators.required, this.roleIdNotZero]],
      roleName: [''],
      rowVersion: [{ value: undefined, disabled: true }]
    })
  }

  private createFromForm(): UserDto {
    return {
      ...this.user,
      id: this.form?.get('id')!.value,
      name: this.form?.get('name')!.value,
      lastName: this.form?.get('lastName')!.value,
      email: this.form?.get('email')!.value,
      roleId: this.form?.get('roleId')!.value,
      roleName: this.form?.get('roleName')!.value,
      rowVersion: this.form?.get('rowVersion')!.value,
    };
  }

  private updateForm(user: UserDto): void {
    this.form?.patchValue({
      id: user.id,
      name: user.name,
      lastName: user.lastName,
      email: user.email,
      roleId: user.roleId,
      roleName: user.roleName,
      rowVersion: user.rowVersion
    });
  }

  roleIdNotZero(control: AbstractControl): ValidationErrors | null {
    return control.value === 0 ? { 'roleIdInvalid': true } : null;
  }
  
  public handleError(error: any): void {
    console.log(error);
    if (error.status === 409) {
      this.errorMessage =
        error.error?.message || "Concurrency error: the user has already been updated by another.";
    } else {
      this.errorMessage = "An unexpected error occurred. Please try again.";
    } 
  }
}
