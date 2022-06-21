namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employees")]
    public partial class Employee
    {
        public int id { get; set; }

        [StringLength(50)]
        public string employeeCode { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(12)]
        public string idCard { get; set; }

        [StringLength(5)]
        public string gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthDate { get; set; }

        [StringLength(30)]
        public string phoneNumber { get; set; }

        [StringLength(90)]
        public string email { get; set; }

        [StringLength(300)]
        public string address { get; set; }

        public bool? status { get; set; }
    }
}
