using DrugstoreManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.System.Users
{
    public class RegisterRequest : RequestBase
    {
        [Display(Name = "Tên")]
        public string? FirstName { get; set; }

        [Display(Name = "Họ")]
        public string? LastName { get; set; }

        [Display(Name = "Mã nhân viên")]
        public int EmployeeId { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Tên đăng nhập")]
        public string? UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
