import { Component, OnInit, ElementRef } from '@angular/core';


@Component({
  selector: 'app-imageslider',
  templateUrl: './imageslider.component.html',
  styleUrls: ['./imageslider.component.css']
})
export class ImageSliderComponent implements OnInit {
  constructor(private elementRef: ElementRef) { }

  images: string[] = [
    './../../assets/patienthome1.jpg',
    './../../assets/patienthome2.jpg',
    './../../assets/patienthome3.jpg'
  ];
  currentSlide: string = this.images[0];
  currentIndex: number = 0;

  ngOnInit() {
    setInterval(() => {
      this.nextSlide();
    }, 3000);
  }

  nextSlide() {
    this.currentIndex = (this.currentIndex === this.images.length - 1) ? 0 : this.currentIndex + 1;
    this.currentSlide = this.images[this.currentIndex];
  }

  scrollToContent() {
    const sliderContainer = this.elementRef.nativeElement.querySelector('.below');
    sliderContainer.scrollIntoView({ behavior: 'smooth', block: 'end' });
  }

}
