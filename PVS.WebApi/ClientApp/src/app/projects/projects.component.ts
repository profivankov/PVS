import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../services/authentication.service';
import { ProjectService } from '../services/projects.service';
import { Project } from '../models/project';

@Component({
  selector: 'projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {
  projects$: Observable<Project[]>;

  currentUser: any;
  

  constructor(
    private projectService: ProjectService,
    private authenticationService: AuthenticationService
    ) {
      this.currentUser = this.authenticationService.currentUserValue;
  }

  ngOnInit() {
    this.loadAllProjects();
  }

  private loadAllProjects() {
    this.projects$ = this.projectService.getProjectByUserId(this.currentUser.id);
  }

  delete(projectId) {
    const ans = confirm('Do you want to delete blog post with id: ' + projectId);
    if (ans) {
      this.projectService.deleteProject(projectId).subscribe((data) => {
        this.loadAllProjects();
      });
    }
  }
}
