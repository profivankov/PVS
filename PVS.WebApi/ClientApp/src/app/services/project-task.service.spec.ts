import { TestBed } from '@angular/core/testing';

import { ProjectTaskService } from './project-task.service';

describe('ProjectTaskService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProjectTaskService = TestBed.get(ProjectTaskService);
    expect(service).toBeTruthy();
  });
});
