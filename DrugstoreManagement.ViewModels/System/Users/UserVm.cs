using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.System.Users
{
    public class UserVm
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public int employeeId { get; set; }

        public DateTime? dateCreated { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }

    }
}
