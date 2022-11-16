import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradientBannerComponent } from './gradient-banner.component';

describe('GradientBannerComponent', () => {
  let component: GradientBannerComponent;
  let fixture: ComponentFixture<GradientBannerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GradientBannerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GradientBannerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
