using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.System.Users
{
    public class UserVm
    {
        public Guid Id { get; set; }

        [Display(Name = "Họ & tên")]
        public string? FullName { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime Dob { get; set; }

        [Display(Name = "Giới tính")]
        public string? Gender { get; set; }

        [Display(Name = "CMT/CCCD")]
        public string? IdCard { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        public int EmployeeId { get; set; }

        [Display(Name = "Mã nhân viên")]
        public string? EmployeeCode { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [Display(Name = "Chức vụ")]
        public string UserRoles { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Lần cuối đăng nhập")]
        public DateTimeOffset? LockoutEnd { get; set; }

        [Display(Name = "Trạng thái")]
        public bool LockoutEnabled { get; set; }

        public string? ImageFilePath { get; set; }
    }
}
