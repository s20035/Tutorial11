using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial11.Entities
{
    public class Prescription_Medicament
    {
        [ForeignKey("Medicament")]
      public int IdMedicament { get; set; }
        [ForeignKey("Prescription")]
        public int IdPrescription { get; set; }
        public int Dose { get; set; }
        public string details { get; set; }

        public virtual Prescription Prescription { get; set; }

        public virtual Medicament Medicament { get; set; }
    }
}
