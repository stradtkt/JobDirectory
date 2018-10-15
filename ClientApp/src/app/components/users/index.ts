import { UserLoginComponent } from './user-login/user-login.component';
import { UserRegisterComponent } from './user-register/user-register.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserListComponent } from './user-list/user-list.component';


export const components: any[] = [
  UserDetailComponent,
  UserListComponent,
  UserLoginComponent,
  UserRegisterComponent
];

export * from './user-detail/user-detail.component';
export * from './user-list/user-list.component';
export * from './user-register/user-register.component';
export * from './user-login/user-login.component';
