namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserRoles")]
    public partial class UserRole
    {
        public int id { get; set; }

        [StringLength(30)]
        public string roleName { get; set; }

        [StringLength(200)]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateCreated { get; set; }

        public bool? createInvoice { get; set; }

        public bool? invoiceManagement { get; set; }

        public bool? warehouseManagement { get; set; }

        public bool? category { get; set; }

        public bool? enterpriseInfor { get; set; }

        public bool? userManagement { get; set; }

        public bool? report { get; set; }

        public bool? setting { get; set; }

        public bool? status { get; set; }

    }
}
