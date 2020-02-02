import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';
import { ProjectService } from '../services/projects.service';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent implements OnInit {
    currentUser: any;
    users = [];
    projects = [];

    constructor(
        private authenticationService: AuthenticationService,
        private userService: UserService,
        private projectService: ProjectService
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        this.loadAllProjects();
    }

    // deleteUser(id: number) {
    //     this.userService.deleteUser(id)
    //         .pipe(first())
    //         .subscribe(() => this.loadAllUsers());
    // }

    private loadAllProjects() {
        this.projectService.getProjectByUserId(this.currentUser.id)
            .pipe(first())
            .subscribe(projects => this.projects = projects);
    }
}