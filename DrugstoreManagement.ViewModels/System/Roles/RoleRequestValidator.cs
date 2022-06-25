using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.System.Roles
{
    public class RoleRequestValidator : AbstractValidator<RoleVm>
    {
        public RoleRequestValidator()
        {
            //RuleFor(x => x.Name).NotEmpty().WithMessage("Tên Role không được để trống");
        }
    }
}
