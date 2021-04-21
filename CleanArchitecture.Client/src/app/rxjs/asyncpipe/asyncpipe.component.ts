import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { share } from 'rxjs/operators';
import { Student } from '../interfaces/interfaces';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-asyncpipe',
  templateUrl: './asyncpipe.component.html',
  styleUrls: ['./asyncpipe.component.scss']
})
export class AsyncpipeComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  student$: Observable<Student> = this.httpService.studentOfTheSecond$

  ngOnInit(): void {
  }

}
