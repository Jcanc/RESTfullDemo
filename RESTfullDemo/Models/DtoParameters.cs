using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfullDemo.Models
{
    public class DtoParameters
    {
        private const int MaxPageSize = 20;
        private int _pageSize = 5;
        public string search { get; set; }

        public int pageInex { get; set; } = 1;

        public int pageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
