using Domain.DAO;
using Domain.Entities;
using Domain.Logic.Base;

namespace Domain.Logic
{
    public class EmployeeLogic : BaseLogic<Employee>
    {
        public EmployeeLogic(DAOFactory parameter) : base(parameter.employeeDAO)
        {
            entity = new Employee();
        }

        public static bool SearchLogic(Employee element, string parameter) => 
            element.IdEmployee.ToString().Contains(parameter) ||
            element.LastName.ToString().Contains(parameter) ||
            element.Name.ToLower().StartsWith(parameter.ToLower());
    }
}
