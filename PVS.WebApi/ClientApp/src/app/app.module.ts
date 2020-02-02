import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserService } from './services/user.service';
import { AuthenticationService } from './services/authentication.service';
import { HomeComponent } from './home/home.component';
import { ProjectsComponent } from './projects/projects.component';
import { ProjectComponent } from './project/project.component';
import { ProjectAddEditComponent } from './project-add-edit/project-add-edit.component';
import { ProjectTaskComponent } from './project-task/project-task.component';
import { ProjectTaskAddEditComponent } from './project-task-add-edit/project-task-add-edit.component';
import { ProjectMemberComponent } from './project-member/project-member.component';
import { ProjectMemberAddEditComponent } from './project-member-add-edit/project-member-add-edit.component'

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    ProjectsComponent,
    ProjectComponent,
    ProjectAddEditComponent,
    ProjectTaskComponent,
    ProjectTaskAddEditComponent,
    ProjectMemberComponent,
    ProjectMemberAddEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    UserService,
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
