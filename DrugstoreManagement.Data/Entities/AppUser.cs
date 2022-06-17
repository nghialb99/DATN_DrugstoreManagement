using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime Dob { get; set; }

        public int employeeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateCreated { get; set; }


    }
}
