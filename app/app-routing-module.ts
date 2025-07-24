import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentLibrarydetailsComponent } from './student-librarydetails-component/student-librarydetails-component';

const routes: Routes = [
  { path: '', component: StudentLibrarydetailsComponent },
 // { path: 'library', component: StudentLibrarydetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
