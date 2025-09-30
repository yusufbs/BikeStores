import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HtmlToDocx } from './html-to-docx';

describe('HtmlToDocx', () => {
  let component: HtmlToDocx;
  let fixture: ComponentFixture<HtmlToDocx>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HtmlToDocx]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HtmlToDocx);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
