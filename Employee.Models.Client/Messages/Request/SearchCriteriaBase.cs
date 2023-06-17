﻿using System;
using System.ComponentModel.DataAnnotations;
using Employee.Models.Client.Enumerations;

namespace Employee.Models.Client.Messages.Request
{
    public class SearchCriteriaBase
    {
        public const int DefaultPageSieze = 25;

        [StringLength(50)]
        public string SortFieldName { get; set; }

        public SortDirection SortDirection { get; set; }

        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }

        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }

        public SearchCriteriaBase()
        {
            SortDirection = SortDirection.Ascending;
            PageNumber = 1;
            PageSize = DefaultPageSieze;
        }

        public virtual void UpdateCriteria(string sortFieldName, int pageNumer = 1)
        {
            var criteria = this;

            if (!string.IsNullOrEmpty(sortFieldName))
            {
                if (sortFieldName == criteria.SortFieldName)
                {
                    if (criteria.SortDirection == SortDirection.Descending)
                    {
                        criteria.SortDirection = SortDirection.Ascending;
                    }
                }
            }

            if (PageNumber <= 0)
            {
                PageNumber = 1;
            }

            criteria.PageNumber = pageNumer;

            if (criteria.PageSize < DefaultPageSieze)
            {
                criteria.PageSize = DefaultPageSieze;
            }
        }
    }
}

