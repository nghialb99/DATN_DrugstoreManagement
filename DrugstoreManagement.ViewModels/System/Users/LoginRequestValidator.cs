﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Tên đăng nhập đang trống");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Mật khẩu đang trống");
        }
    }
}
