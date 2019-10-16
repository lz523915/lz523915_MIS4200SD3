using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lz523915_MIS4200.Models
{
    public class Vet
    {
        public int vetId { get; set; }
        public string vetFirstName { get; set; }
        public string vetLastName { get; set; }
        public ICollection<Pet> Pet { get; set; }
    }
    public class Pet
    {
        public int petId { get; set; }
        public string petBreed { get; set; }
        public string petOwnerName { get; set; }
        public DateTime dateOfLastVisit { get; set; }
        public ICollection<VisitDetail> VisitDetail { get; set; }
        public int vetId { get; set; }
        public virtual Vet Vet { get; set; }
    }

    public class Treatment
    {
        public int treatmentId { get; set;}
        public string treatmentDescription { get; set;}
        public decimal treatmentCost { get; set; }
        public ICollection<VisitDetail> VisitDetail { get; set; }
    }
    public class VisitDetail
    {
        public int visitDetailId { get; set; }
        public decimal visitPrice { get; set; }
        public int petId { get; set; }
        public virtual Pet Pet { get; set; }
        public int treatmentId { get; set; }
        public virtual Treatment Treatment {get; set;}
    }
}