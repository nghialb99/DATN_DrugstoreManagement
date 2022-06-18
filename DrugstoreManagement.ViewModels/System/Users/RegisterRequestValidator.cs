using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Họ không được để trống")
                .MaximumLength(50).WithMessage("Không được vượt quá 50 kí tự");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Tên không được để trống")
                .MaximumLength(20).WithMessage("Không được vượt quá 20 kí tự");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Tuổi không hợp lệ");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không được để trống")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email không đúng định dạng");

            //RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Tên đăng nhập không được để trống");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Không được để trống")
                .MinimumLength(6).WithMessage("Mật khẩu tối thiểu 6 kí tự");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("không được để trống");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Mật khẩu không trùng");
                }
            });
        }
    }
}
