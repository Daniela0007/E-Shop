import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-test-error',
  standalone: true,
  imports: [
    MatButton
  ],
  templateUrl: './test-error.component.html',
  styleUrl: './test-error.component.scss'
})
export class TestErrorComponent {
  baseUrl = 'https://localhost:5001/api/';
  private http = inject(HttpClient);
  validationErrors?: string[];

  get404Error(){
    this.http.get(this.baseUrl + 'bug/NotFound').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  get400Error(){
    this.http.get(this.baseUrl + 'bug/badrequest').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  get401Error(){
    this.http.get(this.baseUrl + 'bug/unauthorized').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  get500Error(){
    this.http.get(this.baseUrl + 'bug/internalerror').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  get400ValidationError(){
    this.http.post(this.baseUrl + 'bug/ValidationError', {}).subscribe({
      next: response => console.log(response),
      error: error => this.validationErrors = error
    })
  }
}
