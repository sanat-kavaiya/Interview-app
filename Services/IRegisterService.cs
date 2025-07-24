using myApp.Models;
using myApp.Views;

namespace myApp.Services
{
    public interface IRegisterService
    {
        StudentDTO AddRecord(StudentDTO record);
        //    LibraryRecord GetRecordById(int id);
        IEnumerable<Company_MDL> GetCompRecords();
        IEnumerable<Employee_MDL> GetEmpRecords();
        UserGetView GetUserDetail(string username, string password);
    }
}
