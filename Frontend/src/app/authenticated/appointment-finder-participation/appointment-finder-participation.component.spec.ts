import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentFinderParticipationComponent } from './appointment-finder-participation.component';

describe('AppointmentFinderParticipationComponent', () => {
  let component: AppointmentFinderParticipationComponent;
  let fixture: ComponentFixture<AppointmentFinderParticipationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppointmentFinderParticipationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppointmentFinderParticipationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
