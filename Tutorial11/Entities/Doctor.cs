using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial11.Entities
{
    public class Doctor
    {

    public int IdDoctor { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EMail { get; set; }

        public ICollection<Prescription> Prescriptions  { get; set; }
    }
}
