import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ProjectService } from '../services/projects.service';
import { Project } from '../models/project';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.scss']
})
export class ProjectComponent implements OnInit {
  project$: Observable<Project>;
  projectId: Guid;

  constructor(private projectService: ProjectService, private avRoute: ActivatedRoute) {
    const idParam = 'id';
    if (this.avRoute.snapshot.params[idParam]) {
      this.projectId = this.avRoute.snapshot.params[idParam];
    }
  }

  ngOnInit() {
    this.loadProject();
  }

  loadProject() {
    this.project$ = this.projectService.getProject(this.projectId);
  }
}
