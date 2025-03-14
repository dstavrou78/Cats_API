﻿namespace Cats_API.Models
{
    public class QueryParameters
    {
        const int _maxSize = 100;  // max page size
        private int _size = 10;    // default page size

        public int Page { get; set; } = 1;

        public int PageSize
        {
            get { return _size; }
            set
            {
                _size = Math.Min(_maxSize, value);
            }
        }

        public string SortBy { get; set; } = "Id";

        private string _sortOrder = "asc";
        public string SortOrder
        {
            get
            {
                return _sortOrder;
            }
            set
            {
                if (value == "asc" || value == "desc")
                {
                    _sortOrder = value;
                }
            }
        }
    }
}