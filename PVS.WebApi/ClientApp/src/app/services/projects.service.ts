import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Project } from '../models/project';
import { Guid } from "guid-typescript";

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
      this.myAppUrl = environment.appUrl;
      this.myApiUrl = 'api/projects/';
  }

  getProject(projectId: Guid): Observable<Project> {
    return this.http.get<Project>(this.myAppUrl + this.myApiUrl + projectId)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
}

  getProjectByUserId(userId: number): Observable<Project[]> {
      return this.http.get<Project[]>(this.myAppUrl + this.myApiUrl + "byuser/" + userId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  saveProject(project): Observable<Project> {
      return this.http.post<Project>(this.myAppUrl + this.myApiUrl, JSON.stringify(project), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateProject(projectId: Guid, project): Observable<Project> {
      return this.http.put<Project>(this.myAppUrl + this.myApiUrl, JSON.stringify(project), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteProject(projectId: number): Observable<Project> {
      return this.http.delete<Project>(this.myAppUrl + this.myApiUrl + projectId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}