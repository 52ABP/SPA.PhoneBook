import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateOrEditPersonModalComponent } from './create-or-edit-person-modal.component';

describe('CreateOrEditPersonModalComponent', () => {
  let component: CreateOrEditPersonModalComponent;
  let fixture: ComponentFixture<CreateOrEditPersonModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateOrEditPersonModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateOrEditPersonModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
