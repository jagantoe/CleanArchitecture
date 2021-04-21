import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Project } from '../../interfaces/interfaces';

@Component({
  selector: 'app-combinelatest',
  templateUrl: './combinelatest.component.html',
  styleUrls: ['./combinelatest.component.scss']
})
export class CombinelatestComponent implements OnInit {

  constructor() { }

  projects$: Observable<Project[]>;

  ngOnInit(): void {
  }

}
