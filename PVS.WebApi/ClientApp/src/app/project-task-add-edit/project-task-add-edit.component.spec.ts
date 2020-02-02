import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectTaskAddEditComponent } from './project-task-add-edit.component';

describe('ProjectTaskAddEditComponent', () => {
  let component: ProjectTaskAddEditComponent;
  let fixture: ComponentFixture<ProjectTaskAddEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectTaskAddEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectTaskAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
