using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VacationDays.Models
{
    public class EmployeeModel
    {
        public int ID {get; set;}
        [Display(Name = "Vacation Days")]
        public float VacationDays {get; set;}
        public int MaxVacationDays {get; set;}
        [Display(Name = "Days Worked")]
        public int TotalDaysWorked {get; set;}
        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeStatus {get; set;}
        public int DaysToWork {get; set;}
        public float TimeTakingOff { get; set;}
    }
}