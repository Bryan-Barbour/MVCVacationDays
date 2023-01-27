using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationDays.Models;

namespace VacationDays.Data
{
    public class EmployeeData
    {
        public EmployeeData() {
        }

        BaseData data = BaseData.GetInstance;
        public void Work(EmployeeModel dto) {
            
            var employee = data.employees.First(e => e.ID.Equals(dto.ID));

            if( employee.TotalDaysWorked + dto.DaysToWork <= 260) 
            {
                employee.TotalDaysWorked += dto.DaysToWork;
                employee.VacationDays = employee.TotalDaysWorked * (employee.MaxVacationDays / 260f);
                // data.employees.First(e => e.ID == employee.ID).TotalDaysWorked = employee.TotalDaysWorked;
                // data.employees.First(e => e.ID == employee.ID).VacationDays = employee.VacationDays;
            }
        }

        public void TakeVacation(EmployeeModel dto) {
            var employee = data.employees.First(e => e.ID.Equals(dto.ID));

            if( employee.VacationDays - dto.TimeTakingOff >= 0)
            {
                employee.VacationDays -= dto.TimeTakingOff;
            } 
        }

        public List<EmployeeModel> GetEmployees() {
            Console.WriteLine("GetEmployees Count: " + data.employees.Count);
            return data.employees;
        }

        public EmployeeModel GetEmployee(int id) {
            return data.employees.First(e => e.ID.Equals(id));
        }
    }

    public class BaseData 
    {
        private static readonly BaseData instance = new BaseData();
        private BaseData() { employees = new List<EmployeeModel>(); CreateData(); }
        public static BaseData GetInstance { get {return instance;}}
        private void CreateData()
        {
            //employees = new List<EmployeeModel>();
            for(int i = 0; i < 30; i++) {
                employees.Add(new EmployeeModel(){
                    ID = i,
                    VacationDays = 0,
                    TotalDaysWorked = 0,
                    EmployeeStatus = i < 10 ? EmployeeType.Hourly : 
                        i < 20 ? EmployeeType.Salaried : EmployeeType.Manager,
                    MaxVacationDays = (i < 10) ? 10 : (i < 20) ? 15 : 30
                });
            }
            Console.WriteLine("Data created. Data count: " + employees?.Count);
        }
        public List<EmployeeModel> employees {get; set;}
    }
}