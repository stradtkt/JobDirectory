import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent {
  public login: LoginUser[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<LoginUser[]>(baseUrl + 'api/User/RegisterUser')
      .subscribe(result => {
        this.login = result;
      }, error => console.error(error));
    }
  }
interface LoginUser {
  email: string;
  password: string;
}
