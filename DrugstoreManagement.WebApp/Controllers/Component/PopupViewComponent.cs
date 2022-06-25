using DrugstoreManagement.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers.Component
{
    public class PopupViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(Popup result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
