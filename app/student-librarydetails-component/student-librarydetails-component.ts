
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../Models/Employee_MDL';
import { Company } from '../Models/Company_MDL';

@Component({
  selector: 'app-student-librarydetails-component',
  standalone: false,
  templateUrl: './student-librarydetails-component.html',
  styleUrl: './student-librarydetails-component.css'
})
export class StudentLibrarydetailsComponent {
  StudentForm: FormGroup = new FormGroup({});
  employmentTypes: Employee[] = [];
  companies: Company[] = [];
  isLoginMode = false;
  ExtraMessage = '';

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.Dropdownbind();
    this.createForm();
  }

  createForm() {
    this.StudentForm = this.fb.group({
      studentName: ['', Validators.required],
      EmployeeName: ['', this.isLoginMode ? '' : Validators.required],
      CompanyName: ['', this.isLoginMode ? '' : Validators.required],
      Password: ['', Validators.required]
    });
  }

  onSubmit() {
    if(this.isLoginMode){
      this.http.get('https://localhost:7146/Register/GetByUser?userName=' + this.StudentForm.value.studentName+'&Password=' + this.StudentForm.value.Password)
        .subscribe({
          next: (response : any) => {
           // Must provide values for ALL form controls
           // After loading companies data
this.StudentForm.patchValue({
  CompanyName: response.compDetail?.company_id, // Set your default company ID here
  EmployeeName: response.empDetail?.empId // Set your default employee ID here
 });
//            this.employmentTypes = response.empDetail || [];
//            this.companies = response.compDetail || [];
this.ExtraMessage = 'student Registred'
          },
          error: (error) => {
            console.error('Error:', error);
            alert('Error fetching record. Please try again.');
          }
        });
    }
    else{
if (this.StudentForm.valid) {
      const formData = this.StudentForm.value;
      var TempObj = this.transformFormData(formData);
      
      // API call to your C# backend
      this.http.post('https://localhost:7146/Register', TempObj)
        .subscribe({
          next: (response) => {
            console.log('Success:', response);
            alert('record saved successfully!');
            this.onClear();
          },
          error: (error) => {
            console.error('Error:', error);
            alert('Error saving record. Please try again.');
          }
        });
    } else {
      alert('Please fill all required fields.');
    }
    }
  }

  onClear() {
    this.StudentForm.reset();
  }

  Dropdownbind(){
     this.http.get('https://localhost:7146/Register/GetDropownData')
        .subscribe({
          next: (response : any) => {
           // Must provide values for ALL form controls
           this.employmentTypes = response.empRecords || [];
           this.companies = response.compRecords || [];
          },
          error: (error) => {
            console.error('Error:', error);
            alert('Error fetching record. Please try again.');
          }
        });
  }

  transformFormData(formData: any) {
  return {
    StudentName: formData.studentName,
    EmpId: Number(formData.EmployeeName),
    Company_id: Number(formData.CompanyName),
    Password: formData.Password,

  };
}

  toggleMode(isLogin: boolean) {
    this.ExtraMessage = '';
    this.isLoginMode = isLogin;
    this.createForm(); // Recreate form with updated validators
    if(this.isLoginMode == true){
      this.StudentForm.get('EmployeeName')?.disable();
      this.StudentForm.get('CompanyName')?.disable();
    }
    else{
      this.StudentForm.get('EmployeeName')?.enable();
      this.StudentForm.get('CompanyName')?.enable();
    }
  }
}

