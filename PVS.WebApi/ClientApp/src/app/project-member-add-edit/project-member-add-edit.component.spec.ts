import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectMemberAddEditComponent } from './project-member-add-edit.component';

describe('ProjectMemberAddEditComponent', () => {
  let component: ProjectMemberAddEditComponent;
  let fixture: ComponentFixture<ProjectMemberAddEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectMemberAddEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectMemberAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
