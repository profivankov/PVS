import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { ProjectsComponent } from './projects/projects.component';
import { ProjectComponent } from './project/project.component';
import { ProjectAddEditComponent } from './project-add-edit/project-add-edit.component';
import { ProjectTaskAddEditComponent } from './project-task-add-edit/project-task-add-edit.component';
import { ProjectTaskComponent } from './project-task/project-task.component';
import { ProjectMemberComponent } from './project-member/project-member.component';
import { ProjectMemberAddEditComponent } from './project-member-add-edit/project-member-add-edit.component';

const routes: Routes = [
  { path: '', component: LoginComponent, pathMatch: 'full' },
  { path: 'register', component: RegisterComponent },
  { path: 'home', component: HomeComponent },
  { path: 'projects', component: ProjectsComponent},
  { path: 'project/:id', component: ProjectComponent },
  { path: 'projects/add', component: ProjectAddEditComponent },
  { path: 'projects/edit/:id', component: ProjectAddEditComponent },
  { path: 'projects/tasks', component: ProjectTaskComponent},
  { path: 'projects/tasks/add', component: ProjectTaskAddEditComponent },
  { path: 'projects/members', component: ProjectMemberComponent },
  { path: 'projects/members/add', component: ProjectMemberAddEditComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
