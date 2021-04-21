import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-share',
  templateUrl: './share.component.html',
  styleUrls: ['./share.component.scss']
})
export class ShareComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  student$ = this.httpService.studentOfTheSecond$;

  ngOnInit(): void {
  }

}
