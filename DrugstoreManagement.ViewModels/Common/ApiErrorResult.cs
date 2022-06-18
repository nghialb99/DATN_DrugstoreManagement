using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[]? ValidatetionErors { get; set; }
        public ApiErrorResult() { }
        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }
        public ApiErrorResult(string[] messages)
        {
            IsSuccessed = false;
            ValidatetionErors = messages;
        }
    }
}
