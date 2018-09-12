import { Value } from './../../_models/value';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-value-card',
  templateUrl: './value-card.component.html',
  styleUrls: ['./value-card.component.css']
})
export class ValueCardComponent implements OnInit {
  @Input() value: Value;

  constructor() { }

  ngOnInit() {
  }

}
