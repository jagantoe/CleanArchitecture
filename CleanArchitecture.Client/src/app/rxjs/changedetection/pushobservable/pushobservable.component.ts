import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { combineLatest, observable, Observable } from 'rxjs';
import { combineAll, map, startWith, tap } from 'rxjs/operators';
import { Student } from '../../interfaces/interfaces';

@Component({
  selector: 'app-pushobservable',
  templateUrl: './pushobservable.component.html',
  styleUrls: ['./pushobservable.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PushobservableComponent implements OnInit {

  @Input() students$: Observable<Student[]>;

  filteredStudents$: Observable<Student[]>;

  filter: FormControl = new FormControl("");

  constructor() { }

  ngOnInit(): void {
    this.filteredStudents$ = combineLatest([this.students$, this.filter.valueChanges.pipe(startWith(this.filter.value))]).pipe(
      map(([students, filter]) => students.filter(_ => _.name.includes(filter)))
    );
  }

  changeDetectionTrigger() {
    console.log("Change detection: Push Observable");
  }
}
