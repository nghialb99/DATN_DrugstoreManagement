﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.Common
{
    public class PageResult<T> : PagingRequestBase
    {
        public List<T> Items { get; set; }
        public int TotalRecords { get; set; }
    }
}
