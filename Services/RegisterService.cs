using myApp.Data;
using myApp.Models;
using myApp.Views;

namespace myApp.Services
{
    public class LibraryService : IRegisterService
    {
        private readonly ApplicationDbContext _context;

        public LibraryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public StudentDTO AddRecord(StudentDTO record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }
           
                bool NameExist = _context.StudentDetail.Any(a => a.StudentName == record.StudentName);
                if (NameExist)
                {
                    return null;
                }
            var Temprecord = new StudentDetails_MDL
            {
                Company_id = record.Company_id,
                EmpId = record.EmpId,
                StudentName = record.StudentName,
                Password = record.Password
                // Company and Employee will be handled by EF via foreign keys
            };
            _context.StudentDetail.Add(Temprecord);
            
            _context.SaveChanges();
            return record;
        }

        public IEnumerable<Company_MDL> GetCompRecords()
        {
            return _context.CompanyDetail.ToList();
        }

        public IEnumerable<Employee_MDL> GetEmpRecords()
        {
            return _context.EmployeDetail.ToList();
        }

        public UserGetView GetUserDetail(string username, string password)
        {
            StudentDetails_MDL TempStudent = (StudentDetails_MDL)_context.StudentDetail.
                Where(s => s.StudentName == username && s.Password == password).FirstOrDefault();
            if (TempStudent == null)
                return null;
            Company_MDL TempCompany = (Company_MDL)_context.CompanyDetail.Where(c => c.Company_id == TempStudent.Company_id).FirstOrDefault();
            Employee_MDL TempEmployee = (Employee_MDL)_context.EmployeDetail.Where(e => e.EmpId == TempStudent.EmpId).FirstOrDefault();
            UserGetView TempResult = new UserGetView()
            {
                StudentDtl = TempStudent,
                CompDetail = TempCompany,
                EmpDetail= TempEmployee,
            };
            return TempResult;
            //return _context.LibraryRecords.FirstOrDefault(r => r.Id == id);
        }
    }
}
