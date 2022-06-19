using DrugstoreManagement.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers.Component
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
