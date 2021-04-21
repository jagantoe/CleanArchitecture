import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { Student } from '../../interfaces/interfaces';

@Component({
  selector: 'app-push',
  templateUrl: './push.component.html',
  styleUrls: ['./push.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PushComponent implements OnInit {

  constructor() { }

  @Input() students: Student[];

  filteredStudents: Student[];

  ngOnInit(): void {
    this.filteredStudents = this.students;
  }

  changeDetectionTrigger() {
    console.log("Change detection: Push");
  }

  filterTrigger(value) {
    this.filteredStudents = this.students.filter(_ => _.name.includes(value));
  }
}
