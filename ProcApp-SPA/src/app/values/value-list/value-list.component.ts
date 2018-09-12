import { ActivatedRoute } from '@angular/router';
import { ValueService } from './../../_services/value.service';
import { Value } from './../../_models/value';
import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-value-list',
  templateUrl: './value-list.component.html',
  styleUrls: ['./value-list.component.css']
})
export class ValueListComponent implements OnInit {
  values: Value[];

  constructor(private valueService: ValueService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.values = data['values'];
    });
  }

}
