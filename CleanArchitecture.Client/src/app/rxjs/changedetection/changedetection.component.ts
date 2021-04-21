import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../interfaces/interfaces';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-changedetection',
  templateUrl: './changedetection.component.html',
  styleUrls: ['./changedetection.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ChangedetectionComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  students$: Observable<Student[]> = this.httpService.students$
  ngOnInit(): void {
  }

  topTen() {
    this.httpService.topTenStudents();
  }
}
