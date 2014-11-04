using System.Collections.Generic;

namespace NestedModels.Models
{
    public class Employee
    {
        public Employee()
        {
            Phones = new HashSet<Phone>();
        }

        public int EmployeeId { set; get; }
        public string Name { get; set; }
        public string Salary { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

        internal void CreatePhoneNumbers(int count = 2)
        {
            for (int i = 0; i < count; i++)
            {
                Phones.Add(new Phone());
            }
        }
    }
}