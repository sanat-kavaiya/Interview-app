import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentLibrarydetailsComponent } from './student-librarydetails-component';

describe('StudentLibrarydetailsComponent', () => {
  let component: StudentLibrarydetailsComponent;
  let fixture: ComponentFixture<StudentLibrarydetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StudentLibrarydetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StudentLibrarydetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
