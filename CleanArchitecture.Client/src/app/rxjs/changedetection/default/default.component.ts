import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { Student } from '../../interfaces/interfaces';

@Component({
  selector: 'app-default',
  templateUrl: './default.component.html',
  styleUrls: ['./default.component.scss'],
  changeDetection: ChangeDetectionStrategy.Default
})
export class DefaultComponent implements OnInit {

  constructor() { }

  @Input() students: Student[];

  filteredStudents: Student[];

  ngOnInit(): void {
    this.filteredStudents = this.students;
  }

  changeDetectionTrigger() {
    console.log("Change detection: Default");
  }

  filterTrigger(value: string) {
    this.filteredStudents = this.students.filter(_ => _.name.includes(value));
  }

}
