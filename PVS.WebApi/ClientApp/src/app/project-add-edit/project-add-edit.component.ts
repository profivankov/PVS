import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { ProjectService } from '../services/projects.service';
import { Project } from '../models/project';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-project-add-edit',
  templateUrl: './project-add-edit.component.html',
  styleUrls: ['./project-add-edit.component.scss']
})
export class ProjectAddEditComponent implements OnInit {
  form: FormGroup;
  actionType: string;
  formTitle: string;
  formBody: string;
  projectId: Guid;
  errorMessage: any;
  currentUser: any;
  existingProject: Project;

  constructor(private projectService: ProjectService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router, private authenticationService: AuthenticationService) {
    const idParam = 'id';
    this.actionType = 'Add';
    this.formTitle = 'title';
    this.formBody = 'body';
    this.currentUser = this.authenticationService.currentUserValue;
    if (this.avRoute.snapshot.params[idParam]) {
      this.projectId = this.avRoute.snapshot.params[idParam];
    }
    else{
      this.projectId = null;
    }

    this.form = this.formBuilder.group(
      {
        projectId: 0,
        title: ['', [Validators.required]],
        body: ['', [Validators.required]],
      }
    )
  }

  ngOnInit() {

    if (this.projectId != null) {
      this.actionType = 'Edit';
      this.projectService.getProject(this.projectId)
        .subscribe(data => (
          this.existingProject = data,
          this.form.controls[this.formTitle].setValue(data.projectName),
          this.form.controls[this.formBody].setValue(data.description)
        ));
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Add') {
      let project: Project = {
        id: this.currentUser.id,
        userId: this.currentUser.id,
        projectName: this.form.get(this.formTitle).value,
        description: this.form.get(this.formBody).value
      };

      this.projectService.saveProject(project)
        .subscribe((data) => {
          this.router.navigate(['/project/', data.id]);
        });
    }

    if (this.actionType === 'Edit') {
      let project: Project = {
        id: this.projectId,
        userId: this.currentUser.id,
        projectName: this.form.get(this.formTitle).value,
        description: this.form.get(this.formBody).value
      };
      this.projectService.updateProject(project.id, project)
        .subscribe((data) => {
          this.router.navigate(['/project/', data.id]);
        });
    }
  }

  cancel() {
    this.router.navigate(['/projects']);
  }

  get title() { return this.form.get(this.formTitle); }
  get body() { return this.form.get(this.formBody); }
}