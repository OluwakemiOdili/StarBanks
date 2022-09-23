using StarBanks.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBanks.Shared
{
    public class Employee
    {
        public int EmployeeId { get; set; } //Primary key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }//Foreign key
        public string PhotoPath { get; set; }
        public Department Department { get; set; } //Navigation Property i.e shows relationship...helps to move from one table to another
    }
}