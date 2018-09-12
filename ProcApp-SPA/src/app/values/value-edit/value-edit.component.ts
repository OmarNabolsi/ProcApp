import { AlertifyService } from './../../_services/alertify.service';
import { ValueService } from './../../_services/value.service';
import { Value } from './../../_models/value';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-value-edit',
  templateUrl: './value-edit.component.html',
  styleUrls: ['./value-edit.component.css']
})
export class ValueEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  value: Value;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(private route: ActivatedRoute,
    private alertify: AlertifyService
  ) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.value = data['value'];
    });
  }

  updateValue() {
    console.log(this.value);
    this.alertify.success('Value has been updated!');
    this.editForm.reset(this.value);
  }

}
