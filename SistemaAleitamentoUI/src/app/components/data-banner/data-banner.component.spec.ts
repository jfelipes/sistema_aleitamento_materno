import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataBannerComponent } from './data-banner.component';

describe('DataBannerComponent', () => {
  let component: DataBannerComponent;
  let fixture: ComponentFixture<DataBannerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DataBannerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DataBannerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
