import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { AssignmentComponent } from './assignment/assignment.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TabComponent } from './tab/tab.component';
import { TabFormComponent } from './tab/tab-form/tab-form.component';
import { TabDialog } from './tab/tab-dialog/tab-dialog.component';
import { AssignmentDialogComponent } from './assignment/assignment-dialog/assignment-dialog.component'
import { environment } from 'src/environments/environment';
import { BaseUrlInterceptor } from './shared/base-url.interceptor';

import { MatSliderModule } from '@angular/material/slider';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BoardComponent } from './board/board.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@NgModule({
  declarations: [
    AppComponent,
    AssignmentComponent,
    TabComponent,
    TabFormComponent,
    BoardComponent,
    TabDialog,
    AssignmentDialogComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    MatSliderModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule,
    MatCardModule,
    MatToolbarModule,
    MatDialogModule,
    MatIconModule,
    MatProgressSpinnerModule
  ],
  providers: [
    {
      provide: "BASE_API_URL",
      useValue: environment.apiUrl
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: BaseUrlInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
