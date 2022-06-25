using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.Common
{
    public class Popup
    {
        public string? PopupId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ActionName { get; set; }
        public Guid RouteId { get; set; }
    }
}
