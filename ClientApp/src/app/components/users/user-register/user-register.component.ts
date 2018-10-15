import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent {
  public register: RegisterUser[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<RegisterUser[]>(baseUrl + 'api/User/RegisterUser')
      .subscribe(result => {
        this.register = result;
      }, error => console.error(error));
    }
  }
interface RegisterUser {
  name: string;
  email: string;
  username: string;
  password: string;
  confirm: string;
}
