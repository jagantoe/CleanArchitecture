import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of, timer } from 'rxjs';
import { delay, map, repeat, share, tap } from 'rxjs/operators';
import { Project, Student } from '../interfaces/interfaces';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private projects: Project[] = [
    { id: 1, name: "Necromancy", description: "Raise the dead.", students: [] },
    { id: 2, name: "Pilot Training", description: "Fly a plane.", students: [] },
    { id: 3, name: "Pigeon Race", description: "Train pigeon to fly somewhere.", students: [] },
    { id: 4, name: "Alchemy", description: "Transmute lead to gold.", students: [] },
    { id: 5, name: "App Development", description: "Create a mobile app.", students: [] },
  ]

  private students: Student[] = [
    { id: 1, name: "Bob", projectId: 0 },
    { id: 2, name: "Tom", projectId: 0 },
    { id: 3, name: "Peter", projectId: 0 },
    { id: 4, name: "George", projectId: 0 },
    { id: 5, name: "Fred", projectId: 0 },
    { id: 6, name: "Jim", projectId: 0 },
    { id: 7, name: "Steve", projectId: 0 },
    { id: 8, name: "Dan", projectId: 0 },
    { id: 9, name: "Lucas", projectId: 0 },
    { id: 10, name: "Mary", projectId: 0 },
    { id: 11, name: "Jill", projectId: 0 },
    { id: 12, name: "Mike", projectId: 0 },
    { id: 13, name: "Oscar", projectId: 0 },
    { id: 14, name: "Filip", projectId: 0 },
    { id: 15, name: "John", projectId: 0 },
    { id: 16, name: "James", projectId: 0 },
    { id: 17, name: "Boris", projectId: 0 },
    { id: 18, name: "Sofie", projectId: 0 },
    { id: 19, name: "Kate", projectId: 0 },
    { id: 20, name: "Charles", projectId: 0 },
  ]


  private studentsSubject: BehaviorSubject<Student[]> = new BehaviorSubject<Student[]>(this.students);
  private projectsSubject: BehaviorSubject<Project[]> = new BehaviorSubject<Project[]>(this.projects);

  students$: Observable<Student[]> = this.studentsSubject.asObservable().pipe(
    delay(Math.random() * 1000)
  );

  projects$: Observable<Project[]> = this.projectsSubject.asObservable().pipe(
    delay(Math.random() * 1000)
  );

  studentOfTheSecond$: Observable<Student> = timer(0, 1000).pipe(
    map(_ => this.students[_ % (this.students.length)]),
    tap(_ => console.log(_)),
  )

  constructor() { }

  topTenStudents() {
    this.studentsSubject.next(this.studentsSubject.value.filter(_ => _.id < 10))
  }
}
