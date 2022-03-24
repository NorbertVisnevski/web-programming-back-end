﻿using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingBackEnd.Helpers
{
    public class ProductParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public string Query { get; set; }
        public string OrderPrice { get; set; } = "ascending";
        public double? MinPrice { get; set; } = 0;
        public double? MaxPrice { get; set; }
        [FromQuery(Name = "category")]
        public List<string> Categories { get; set; }
    }
}
