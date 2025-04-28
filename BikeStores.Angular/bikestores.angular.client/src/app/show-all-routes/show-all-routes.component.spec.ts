import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowAllRoutesComponent } from './show-all-routes.component';

describe('ShowAllRoutesComponent', () => {
  let component: ShowAllRoutesComponent;
  let fixture: ComponentFixture<ShowAllRoutesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowAllRoutesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowAllRoutesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
