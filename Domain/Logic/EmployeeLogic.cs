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

        public bool searchLogic(Employee element, string parameter)
        {
            return
                element.IdEmployee.ToString().Contains(parameter.Trim()) ||
                element.LastName.ToString().Contains(parameter.Trim()) ||
                element.Name.ToLower().StartsWith(parameter.Trim().ToLower());
        }
    }
}
