using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SSO.Api.Model
{
    public class PaginationViewModel
    {
        public int Page { get; set; }
        public int Count { get; set; }
    }
}
