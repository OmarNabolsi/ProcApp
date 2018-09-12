import { AlertifyService } from './../../_services/alertify.service';
import { Value } from './../../_models/value';
import { ValueService } from './../../_services/value.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
  selector: 'app-value-detail',
  templateUrl: './value-detail.component.html',
  styleUrls: ['./value-detail.component.css']
})
export class ValueDetailComponent implements OnInit {
  value: Value;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private valueService: ValueService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.value = data['value'];
    });

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ];

    this.galleryImages = this.getImages();
  }

  getImages() {
    const imageUrls = [];
    for (let i = 0; i < this.value.photos.length; i++) {
      imageUrls.push({
        small: this.value.photos[i].url,
        medium: this.value.photos[i].url,
        big: this.value.photos[i].url,
        description: this.value.photos[i].description
      });
    }
    return imageUrls;
  }

}
